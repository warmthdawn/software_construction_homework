using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise7
{
    public partial class MainForm : Form
    {
        private Graphics _graphrics;
        private Pen _pen;
        CancellationTokenSource _source;

        public MainForm()
        {
            InitializeComponent();
        }


        private void btnColor_Click(object sender, EventArgs e)
        {
            using var color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                this.panColor.BackColor = color.Color;
                _pen.Color = color.Color;
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            this.per1 = (double)nudPerRight.Value;
            this.per2 = (double)nudPerLeft.Value;
            this.th1 = (double)nudAngRight.Value * (Math.PI / 180);
            this.th2 = (double)nudAngLeft.Value * (Math.PI / 180);
            int n = (int)nudDepth.Value;

            double x0 = this.panBoard.Width / 2;
            double y0 = this.panBoard.Height * 0.95;
            double len = (double)this.nudLength.Value;
            _graphrics.Clear(Color.White);


            if (_source != null && !_source.IsCancellationRequested)
            {
                _source.Cancel();
            }
            _source = new CancellationTokenSource();
            var source = _source;
            _ = DrawCayleyTreeNonRec(n, x0, y0, len, -Math.PI / 2, _source.Token)
                .ContinueWith(t =>
                {
                    source.Dispose();
                    if (source == _source)
                    {
                        _source = null;
                    }
                });
        }


        private double th1 = 30 * Math.PI / 180;
        private double th2 = 20 * Math.PI / 180;
        private double per1 = 0.6;
        private double per2 = 0.7;
        private async Task DrawCayleyTreeRecursion(int n, double x0, double y0, double len, double th, CancellationToken token)
        {

            if (n <= 0 || token.IsCancellationRequested) return;
            double x1 = x0 + len * Math.Cos(th);
            double y1 = y0 + len * Math.Sin(th);
            await Draw(x0, y0, x1, y1);
            await DrawCayleyTreeRecursion(n - 1, x1, y1, per1 * len, th + th1, token);
            await DrawCayleyTreeRecursion(n - 1, x1, y1, per2 * len, th - th2, token);
        }

        /// <summary>
        /// 非递归写法，看着更舒服(
        /// </summary>
        private async Task DrawCayleyTreeNonRec(int depth, double xStart, double yStart, double maxLength, double defaultTh, CancellationToken token)
        {

            var queue = new Queue<(int, double, double, double, double)>();
            queue.Enqueue((depth, xStart, yStart, maxLength, defaultTh));
            while (queue.Count > 0 || token.IsCancellationRequested)
            {
                (int n, double x0, double y0, double len, double th) = queue.Dequeue();
                if (n <= 0)
                    continue;
                double x1 = x0 + len * Math.Cos(th);
                double y1 = y0 + len * Math.Sin(th);
                await Draw(x0, y0, x1, y1);
                queue.Enqueue((n - 1, x1, y1, per1 * len, th + th1));
                queue.Enqueue((n - 1, x1, y1, per2 * len, th - th2));
            }



        }

        private async Task Draw(double x0, double y0, double x1, double y1)
        {
            Action<double, double, double, double> draw = (x0, y0, x1, y1)
                => _graphrics.DrawLine(_pen, (float)x0, (float)y0, (float)x1, (float)y1);
            await Task.Factory.FromAsync(BeginInvoke(
                draw, x0, y0, x1, y1),
                r => { });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this._graphrics = this.panBoard.CreateGraphics();
            _graphrics.Clear(Color.White);
            this._pen = new Pen(Color.DimGray);
        }


        private void panBoard_Resize(object sender, EventArgs e)
        {
            _graphrics.Dispose();
            this._graphrics = this.panBoard.CreateGraphics();
            _graphrics.Clear(Color.White);
        }
    }
}
