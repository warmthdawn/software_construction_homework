using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    public class Crawler
    {

        public List<string> Urls { get; private set; } = new List<string>();
        public List<string> CompletedUrls { get; private set; } = new List<string>();
        public List<string> DownloadingUrls { get; private set; } = new List<string>();
        private int nameIndex;
        private static readonly Regex HREF_REGEX =
            new Regex(@"(?<=(href|HREF)\s*=\s*[""'])(?<url>[^#][^""'<>]*)(?=[""'])");
        private static readonly Regex URL_REGEX =
            new Regex(@"(http\://|https\://|)[\w\%/\.](\.htm|\.html|\.jsp|\.aspx)[\?\#]*.*");

        private static readonly Regex FILENAME_REGEX =
            new Regex(@"[\w\%]+(?=\.htm|\.html|\.jsp|\.aspx)");
        public int MaxCount { get; set; } = 300;
        public int MaxParallel { get; set; } = 10;
        public string SavePath { get; set; } = "data";

        public event EventHandler CrawComplete;

        public async Task Crawl()
        {
            Console.WriteLine("开始爬了.... ");


            List<Task> downloadTask = new List<Task>();


            while (Urls.Count > 0)
            {
                
                foreach (var current in Urls.ToArray())
                {
                    while (DownloadingUrls.Count >= MaxParallel)
                    {
                        //限制并发
                        await Task.Delay(10);
                    }
                    if(CompletedUrls.Count + DownloadingUrls.Count > MaxCount)
                    {
                        break;
                    }
                    DownloadingUrls.Add(current);
                    Urls.Remove(current);
                    var down = DownLoad(current, nameIndex++.ToString()).ContinueWith((taks =>
                    {
                        CompletedUrls.Add(current);
                        DownloadingUrls.Remove(current);
                        CrawComplete?.Invoke(this, new EventArgs());
                        Parse(taks.Result, current);//解析,并加入新的链接
                        Console.WriteLine($"爬行{current}结束");
                    }));
                    downloadTask.Add(down);
                }
                await Task.WhenAny(downloadTask);
                downloadTask.RemoveAll(t => t.IsCompleted);
            }

            await Task.WhenAll(downloadTask);
        }
        public async Task<string> DownLoad(string url, string name)
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
                Console.WriteLine(ex.Message);
                return "";
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

                if (!Urls.Contains(result) && !CompletedUrls.Contains(result) &&!DownloadingUrls.Contains(result))
                {
                    Urls.Add(result);
                }
            }
        }

    }
}
