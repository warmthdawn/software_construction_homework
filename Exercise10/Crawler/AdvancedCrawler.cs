using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    public class AdvancedCrawler
    {
        public AdvancedCrawler(string initialUrl)
        {
            this.InitialUrl = initialUrl;
        }
        public string InitialUrl { get; private set; }
        public List<string> FailedUrls { get; private set; } = new List<string>();

        private ConcurrentQueue<string> pendingUrls = new ConcurrentQueue<string>();
        public ConcurrentBag<string> CompletedUrls { get; private set; } = new ConcurrentBag<string>();
        public HashSet<string> DownloadingUrls { get; private set; } = new HashSet<string>();
        public object urlLock = new object();
        private int nameIndex;
        private static readonly Regex HREF_REGEX =
            new Regex(@"(?<=(href|HREF)\s*=\s*[""'])(?<url>[^#][^""'<>]*)(?=[""'])");
        private static readonly Regex URL_REGEX =
            new Regex(@"(http\://|https\://|)[\w\%/\.](\.htm|\.html|\.jsp|\.aspx)[\?\#]*.*");

        private static readonly Regex FILENAME_REGEX =
            new Regex(@"[\w\%]+(?=\.htm|\.html|\.jsp|\.aspx)");
        public int MaxCount { get; set; } = 300;
        public int MaxParallel { get; set; } = 25;
        public string SavePath { get; set; } = "data";

        public int MaxRetry { get; set; } = 3;

        public async Task Crawl()
        {
            List<Task> downloadTask = new List<Task>();
            pendingUrls.Enqueue(InitialUrl);


            while (pendingUrls.Count > 0)
            {
                if (!pendingUrls.TryDequeue(out var current))
                {
                    continue;
                };

                if (CompletedUrls.Count + DownloadingUrls.Count > MaxCount)
                {
                    break;
                }

                //限制并发
                if(MaxParallel > 0 && DownloadingUrls.Count >= MaxParallel)
                {
                    await Task.Delay(100);
                    continue;
                }

                //下载开始事件
                var downEvent = new BeforeDownloadEventArgs()
                {
                    Url = current,
                    Cancelled = false
                };
                BeforeDownload?.Invoke(this, downEvent);
                if (!downEvent.Cancelled)
                {
                    lock (urlLock)
                    {
                        DownloadingUrls.Add(current);
                    }
                    var down = DownLoad(current, nameIndex++.ToString())
                        .ContinueWith(taks =>
                    {
                        if (taks.IsFaulted)
                        {
                            FailedUrls.Add(current);
                            lock (urlLock)
                            {
                                DownloadingUrls.Remove(current);
                            }
                            return;
                        }
                        CompletedUrls.Add(current);

                        lock (urlLock)
                        {
                            DownloadingUrls.Remove(current);
                        }
                        var ev = new DownloadedEventArgs()
                        {
                            Html = taks.Result,
                            OverrideUrlParse = false,
                            Url = current
                        };
                        Downloaded?.Invoke(this, ev);
                        //覆盖默认的url解析
                        if (ev.OverrideUrlParse && ev.NextUrls != null)
                        {
                            foreach (var u in ev.NextUrls)
                            {
                                AddPending(u);
                            }
                        }
                        else
                        {
                            Parse(taks.Result, current);//解析,并加入新的链接
                        }



                    });
                    downloadTask.Add(down);
                    Downloading?.Invoke(this, new DownloadingEventArgs() { Url = current });
                }
                if(pendingUrls.Count <= 0)
                {
                    await Task.WhenAny(downloadTask);
                    downloadTask.RemoveAll(t => t.IsCompleted);
                }
            }

            await Task.WhenAll(downloadTask);
            this.CrawlerCompleted?.Invoke(this, new CrawlerCompletedEventArgs()
            {
                FailedCount = FailedUrls.Count,
                SuccessCount = CompletedUrls.Count
            }) ;
        }
        public async Task<string> DownLoad(string url, string name, int retryCount = 0)
        {
            try
            {
                WebClient webClient = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                string html = await webClient.DownloadStringTaskAsync(url);
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                var fName = FILENAME_REGEX.Match(url);
                if (fName.Success)
                {
                    name = name + "_" + fName.Value;
                }
                string fileName = Path.Combine(SavePath, name + ".html");
                await Task.Factory.StartNew(() => File.WriteAllText(fileName, html, Encoding.UTF8));
                return html;
            }
            catch (Exception ex)
            {
                bool retry = retryCount < MaxRetry;
                this.CrawlerFailed?.Invoke(this, new CrawlerFailedEventArgs()
                {
                    Message = $"下载网页{url}失败",
                    RelatedException = ex,
                    Retry = retry
                });
                if (retry)
                {
                    return await DownLoad(url, name, retryCount + 1);
                }

                throw ex;
            }
        }

        private void Parse(string html, string previous)
        {
            Uri uri = new Uri(previous);
            foreach (Match match in HREF_REGEX.Matches(html))
            {
                string url = match.Groups["url"].Value;
                if (!URL_REGEX.IsMatch(url))
                {
                    continue;
                }
                Uri add = new Uri(url, UriKind.RelativeOrAbsolute);
                string result;
                if (url.StartsWith("http://") || url.StartsWith("https://"))
                {
                    if (add.Host != uri.Host)
                    {
                        continue;
                    }
                    result = add.AbsoluteUri;
                }
                else if (!add.IsAbsoluteUri)
                {
                    result = new Uri(uri, add).AbsoluteUri;
                }
                else
                {
                    continue;
                }

                AddPending(result);
            }
        }

        private void AddPending(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                return;
            }
            if(pendingUrls.Count > MaxCount)
            {
                return;
            }
            if (!pendingUrls.Contains(result) &&
                                !CompletedUrls.Contains(result) &&
                                !DownloadingUrls.Contains(result) &&
                                !FailedUrls.Contains(result))
            {
                pendingUrls.Enqueue(result);
            }
        }

        public event EventHandler<CrawlerFailedEventArgs> CrawlerFailed;
        public event EventHandler<BeforeDownloadEventArgs> BeforeDownload;
        public event EventHandler<DownloadingEventArgs> Downloading;
        public event EventHandler<DownloadedEventArgs> Downloaded;
        public event EventHandler<CrawlerCompletedEventArgs> CrawlerCompleted;

        public class DownloadingEventArgs : EventArgs
        {
            public string Url { get; set; }

        }
        public class BeforeDownloadEventArgs : EventArgs
        {
            public bool Cancelled { get; set; }
            public string Url { get; set; }

        }

        public class DownloadedEventArgs : EventArgs
        {
            public string Html { get; set; }
            public bool OverrideUrlParse { get; set; }
            public IEnumerable<string> NextUrls { get; set; }
            public string Url { get; set; }
        }

        public class CrawlerCompletedEventArgs : EventArgs
        {
            public int SuccessCount { get; set; }
            public int FailedCount { get; set; }
        }

        public class CrawlerFailedEventArgs : EventArgs
        {
            public string Url { get; set; }
            public Exception RelatedException { get; set; }
            public string Message { get; set; }
            public bool Retry { get; set; }
        }


    }
}
