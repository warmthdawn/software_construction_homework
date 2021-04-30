using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    public partial class MainForm : Form
    {
        AdvancedCrawler crawler;
        BindingList<DownloadingUrl> DownloadingUrls = new BindingList<DownloadingUrl>();
        object duLock = new object();
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddDown(string url)
        {
            DownloadingUrls.Add(new DownloadingUrl()
            {
                StartTime = DateTime.Now,
                Url = url
            });
        }
        private void RemoveDown(string url)
        {
            for (int i = 0; i < DownloadingUrls.Count; i++)
            {
                if (DownloadingUrls[i].Url == url)
                {
                    DownloadingUrls.RemoveAt(i);
                }
            }

        }

        private void MyInvoke(Action act)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(act);
            }
            else
            {
                act();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumber.Text, out int r))
            {
                return;
            }
            crawler = new AdvancedCrawler(txtUrl.Text)
            {
                MaxCount = r
            };


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            var initPath = Path.Combine(Environment.CurrentDirectory, "data");
            if (!Directory.Exists(initPath))
            {
                Directory.CreateDirectory(initPath);
            }
            fbd.SelectedPath = initPath;
            fbd.ShowNewFolderButton = true;
            if (!(fbd.ShowDialog() == DialogResult.OK))
            {
                return;
            }
            crawler.SavePath = fbd.SelectedPath;

            bdsUrl.DataSource = DownloadingUrls;

            crawler.Downloaded += (s, ev) =>
            {
                this.MyInvoke(() =>
                {
                    RemoveDown(ev.Url);
                    listCompleted.TopIndex = listCompleted.Items.Count - 1;
                    listCompleted.Items.Add(ev.Url);
                });
            };


            crawler.Downloading += (s, ev) =>
            {
                this.MyInvoke(() =>
                {
                    AddDown(ev.Url);
                    this.txtStatus.Text = $"开始下载：{ev.Url}";
                });
            };

            crawler.CrawlerFailed += (s, ev) =>
            {
                this.MyInvoke(() =>
                {
                    RemoveDown(ev.Url);
                    this.txtError.Text = ev.Message;
                });
            };

            crawler.CrawlerCompleted += (s, ev) =>
            {
                this.MyInvoke(() =>
                {
                    timer.Stop();
                    MessageBox.Show($"下载完成！\n成功下载{ev.SuccessCount}\n下载失败{ev.FailedCount}");
                });
            };

            timer.Start();
            _ = crawler.Crawl();
        }

        private void txtNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtNumber.Text, out int r) || r < 0)
            {
                e.Cancel = true;
                epv.SetError(txtNumber, "必须输入数字");
            }
            else
            {

                epv.SetError(txtNumber, "");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MyInvoke(() =>
            {
                foreach (var item in DownloadingUrls)
                {
                    item.RefreshSecond();
                }
            });
        }
    }
}
