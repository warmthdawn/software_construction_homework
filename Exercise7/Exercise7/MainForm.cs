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
        //是否正在绘制，用于显示button
        private bool drawing = false;
        //停止绘制信号
        private bool stopSignal = false;

        

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
                stopSignal = true;
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            //如果正在绘制，退出
            if (drawing)
            {
                stopSignal = true;
                return;
            }

            //获取一波参数
            this.per1 = (double)nudPerRight.Value;
            this.per2 = (double)nudPerLeft.Value;
            this.th1 = (double)nudAngRight.Value * (Math.PI / 180);
            this.th2 = (double)nudAngLeft.Value * (Math.PI / 180);
            int n = (int)nudDepth.Value;

            double x0 = this.panBoard.Width / 2;
            double y0 = this.panBoard.Height * 0.95;
            double len = (double)this.nudLength.Value;

            //填背景，亮色黑背景暗色白背景
            SetBackgroundAndClear();

            ToggleDrawing(true);
            stopSignal = false;

            if (chkRecursion.Checked)
            {
                //递归绘制
                Task.Factory.StartNew(() =>
                {
                    DrawCayleyTreeRecursion(n, x0, y0, len, -Math.PI / 2);
                    Invoke((Action<bool>)ToggleDrawing, false);
                });
            }
            else
            {
                //非递归绘制
                Task.Factory.StartNew(() =>
                {
                    DrawCayleyTreeNonRec(n, x0, y0, len, -Math.PI / 2);
                    Invoke((Action<bool>)ToggleDrawing, false);
                });
            }
        }

        private void SetBackgroundAndClear()
        {
            if (_pen.Color.GetBrightness() > 0.5)
            {
                _graphrics.Clear(Color.Black);
            }
            else
            {
                _graphrics.Clear(Color.White);
            }
        }

        /// <summary>
        /// 标记是否正在绘制
        /// </summary>
        private void ToggleDrawing(bool drawing)
        {
            if (drawing)
            {
                btnDraw.Text = "停止绘制";
            }
            else
            {
                btnDraw.Text = "绘制";
            }
            this.drawing = drawing;
        }


        private double th1 = 30 * Math.PI / 180;
        private double th2 = 20 * Math.PI / 180;
        private double per1 = 0.6;
        private double per2 = 0.7;

        private void DrawCayleyTreeRecursion(int n, double x0, double y0, double len, double th)
        {

            if (n <= 0 || stopSignal) return;
            double x1 = x0 + len * Math.Cos(th);
            double y1 = y0 + len * Math.Sin(th);
            Draw(x0, y0, x1, y1);
            DrawCayleyTreeRecursion(n - 1, x1, y1, per1 * len, th + th1);
            DrawCayleyTreeRecursion(n - 1, x1, y1, per2 * len, th - th2);
        }

        /// <summary>
        /// 非递归写法，层数多的时候看起来不怪
        /// </summary>
        private void DrawCayleyTreeNonRec(int depth, double xStart, double yStart, double maxLength, double defaultTh)
        {

            var queue = new Queue<(int, double, double, double, double)>();
            queue.Enqueue((depth, xStart, yStart, maxLength, defaultTh));
            while (queue.Count > 0 && !stopSignal)
            {
                (int n, double x0, double y0, double len, double th) = queue.Dequeue();
                if (n <= 0)
                    continue;
                double x1 = x0 + len * Math.Cos(th);
                double y1 = y0 + len * Math.Sin(th);
                Draw(x0, y0, x1, y1);
                queue.Enqueue((n - 1, x1, y1, per1 * len, th + th1));
                queue.Enqueue((n - 1, x1, y1, per2 * len, th - th2));
            }



        }

        private void Draw(double x0, double y0, double x1, double y1)
        {
            Action<double, double, double, double> draw = (x0, y0, x1, y1)
                => _graphrics.DrawLine(_pen, (float)x0, (float)y0, (float)x1, (float)y1);

            Invoke(draw, x0, y0, x1, y1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this._graphrics = this.panBoard.CreateGraphics();
            this._pen = new Pen(Color.Pink, 2);
            this.panColor.BackColor = _pen.Color;
        }


        //画板大小改变了，画布要跟着一起改
        private void panBoard_Resize(object sender, EventArgs e)
        {
            stopSignal = true;
            _graphrics.Dispose();
            this._graphrics = this.panBoard.CreateGraphics();
            SetBackgroundAndClear();
        }

    }
}
