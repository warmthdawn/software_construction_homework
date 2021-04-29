using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    public partial class MainForm : Form
    {
        Crawler crawler;
        DateTime lastTime = DateTime.Now;
        object obj = new object();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtNumber.Text, out int r))
            {
                return;
            }
            crawler = new Crawler();
            crawler.MaxCount = r;
            crawler.Urls.Add(txtUrl.Text);
            bdsUrl.DataSource = crawler.Urls;
            bdsCompleted.DataSource = crawler.CompletedUrls;
            crawler.CrawComplete += Crawler_CrawComplete;
            crawler.Crawl().ContinueWith(_ =>
            {
                this.BeginInvoke((Action)(() =>
                {
                    bdsCompleted.ResetBindings(false);
                    bdsUrl.ResetBindings(false);
                    MessageBox.Show("完成");
                }));
            });
        }

        private void Crawler_CrawComplete(object sender, EventArgs e)
        {
            lock (obj)
            {
                if (DateTime.Now - lastTime <= TimeSpan.FromSeconds(1))
                {
                    return;
                }
                lastTime = DateTime.Now;
            }
            this.BeginInvoke((Action)(() =>
            {
                bdsCompleted.ResetBindings(false);
                bdsUrl.ResetBindings(false);
            }));
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
    }
}
