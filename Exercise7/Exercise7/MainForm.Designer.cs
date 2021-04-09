
namespace Exercise7
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.layoutTreeProp = new System.Windows.Forms.TableLayoutPanel();
            this.nudAngLeft = new System.Windows.Forms.NumericUpDown();
            this.nudAngRight = new System.Windows.Forms.NumericUpDown();
            this.nudPerLeft = new System.Windows.Forms.NumericUpDown();
            this.nudPerRight = new System.Windows.Forms.NumericUpDown();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panColor = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPenSize = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.chkRecursion = new System.Windows.Forms.CheckBox();
            this.panBoard = new System.Windows.Forms.Panel();
            this.layoutMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.layoutTreeProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPerRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPenSize)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 2;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.layoutMain.Controls.Add(this.panBoard, 1, 0);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 1;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Size = new System.Drawing.Size(917, 554);
            this.layoutMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 548);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutTreeProp);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cayleys树参数";
            // 
            // layoutTreeProp
            // 
            this.layoutTreeProp.ColumnCount = 2;
            this.layoutTreeProp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.79279F));
            this.layoutTreeProp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.20721F));
            this.layoutTreeProp.Controls.Add(this.nudAngLeft, 1, 5);
            this.layoutTreeProp.Controls.Add(this.nudAngRight, 1, 4);
            this.layoutTreeProp.Controls.Add(this.nudPerLeft, 1, 3);
            this.layoutTreeProp.Controls.Add(this.nudPerRight, 1, 2);
            this.layoutTreeProp.Controls.Add(this.nudLength, 1, 1);
            this.layoutTreeProp.Controls.Add(this.label6, 0, 4);
            this.layoutTreeProp.Controls.Add(this.label5, 0, 5);
            this.layoutTreeProp.Controls.Add(this.label4, 0, 2);
            this.layoutTreeProp.Controls.Add(this.label3, 0, 3);
            this.layoutTreeProp.Controls.Add(this.label2, 0, 1);
            this.layoutTreeProp.Controls.Add(this.label1, 0, 0);
            this.layoutTreeProp.Controls.Add(this.nudDepth, 1, 0);
            this.layoutTreeProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTreeProp.Location = new System.Drawing.Point(3, 19);
            this.layoutTreeProp.Name = "layoutTreeProp";
            this.layoutTreeProp.RowCount = 6;
            this.layoutTreeProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.layoutTreeProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.layoutTreeProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.layoutTreeProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.layoutTreeProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.layoutTreeProp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.layoutTreeProp.Size = new System.Drawing.Size(232, 222);
            this.layoutTreeProp.TabIndex = 0;
            // 
            // nudAngLeft
            // 
            this.nudAngLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAngLeft.Location = new System.Drawing.Point(102, 192);
            this.nudAngLeft.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngLeft.Name = "nudAngLeft";
            this.nudAngLeft.Size = new System.Drawing.Size(127, 23);
            this.nudAngLeft.TabIndex = 11;
            this.nudAngLeft.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nudAngRight
            // 
            this.nudAngRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAngRight.Location = new System.Drawing.Point(102, 155);
            this.nudAngRight.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngRight.Name = "nudAngRight";
            this.nudAngRight.Size = new System.Drawing.Size(127, 23);
            this.nudAngRight.TabIndex = 10;
            this.nudAngRight.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // nudPerLeft
            // 
            this.nudPerLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPerLeft.DecimalPlaces = 2;
            this.nudPerLeft.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPerLeft.Location = new System.Drawing.Point(102, 118);
            this.nudPerLeft.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPerLeft.Name = "nudPerLeft";
            this.nudPerLeft.Size = new System.Drawing.Size(127, 23);
            this.nudPerLeft.TabIndex = 9;
            this.nudPerLeft.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // nudPerRight
            // 
            this.nudPerRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPerRight.DecimalPlaces = 2;
            this.nudPerRight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPerRight.Location = new System.Drawing.Point(102, 81);
            this.nudPerRight.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPerRight.Name = "nudPerRight";
            this.nudPerRight.Size = new System.Drawing.Size(127, 23);
            this.nudPerRight.TabIndex = 8;
            this.nudPerRight.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // nudLength
            // 
            this.nudLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudLength.DecimalPlaces = 1;
            this.nudLength.Location = new System.Drawing.Point(102, 44);
            this.nudLength.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(127, 23);
            this.nudLength.TabIndex = 7;
            this.nudLength.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "右分支角度";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "左分支角度";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "右分支长度比";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "左分支长度比";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "主干长度";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "递归深度";
            // 
            // nudDepth
            // 
            this.nudDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDepth.Location = new System.Drawing.Point(102, 7);
            this.nudDepth.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(127, 23);
            this.nudDepth.TabIndex = 1;
            this.nudDepth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "画笔参数";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.panColor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnColor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.nudPenSize, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(232, 72);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panColor
            // 
            this.panColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panColor.BackColor = System.Drawing.Color.DimGray;
            this.panColor.Location = new System.Drawing.Point(14, 4);
            this.panColor.Name = "panColor";
            this.tableLayoutPanel2.SetRowSpan(this.panColor, 2);
            this.panColor.Size = new System.Drawing.Size(64, 64);
            this.panColor.TabIndex = 0;
            // 
            // btnColor
            // 
            this.btnColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.btnColor, 2);
            this.btnColor.Location = new System.Drawing.Point(115, 6);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(94, 23);
            this.btnColor.TabIndex = 1;
            this.btnColor.Text = "选择画笔颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "粗细";
            // 
            // nudPenSize
            // 
            this.nudPenSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nudPenSize.Location = new System.Drawing.Point(141, 42);
            this.nudPenSize.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPenSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPenSize.Name = "nudPenSize";
            this.nudPenSize.Size = new System.Drawing.Size(88, 23);
            this.nudPenSize.TabIndex = 3;
            this.nudPenSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudPenSize.ValueChanged += new System.EventHandler(this.nudPenSize_ValueChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnDraw, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkRecursion, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 513);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(244, 35);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDraw.Location = new System.Drawing.Point(149, 6);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 3;
            this.btnDraw.Text = "绘制Cayles树";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // chkRecursion
            // 
            this.chkRecursion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkRecursion.AutoSize = true;
            this.chkRecursion.Location = new System.Drawing.Point(23, 7);
            this.chkRecursion.Name = "chkRecursion";
            this.chkRecursion.Size = new System.Drawing.Size(75, 21);
            this.chkRecursion.TabIndex = 4;
            this.chkRecursion.Text = "递归绘制";
            this.chkRecursion.UseVisualStyleBackColor = true;
            // 
            // panBoard
            // 
            this.panBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBoard.Location = new System.Drawing.Point(253, 3);
            this.panBoard.Name = "panBoard";
            this.panBoard.Size = new System.Drawing.Size(661, 548);
            this.panBoard.TabIndex = 1;
            this.panBoard.Resize += new System.EventHandler(this.panBoard_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 554);
            this.Controls.Add(this.layoutMain);
            this.MinimumSize = new System.Drawing.Size(600, 440);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.layoutMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.layoutTreeProp.ResumeLayout(false);
            this.layoutTreeProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPerLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPerRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPenSize)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panBoard;
        private System.Windows.Forms.TableLayoutPanel layoutTreeProp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAngLeft;
        private System.Windows.Forms.NumericUpDown nudAngRight;
        private System.Windows.Forms.NumericUpDown nudPerLeft;
        private System.Windows.Forms.NumericUpDown nudPerRight;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.CheckBox chkRecursion;
        private System.Windows.Forms.CheckBox chkRecure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPenSize;
    }
}