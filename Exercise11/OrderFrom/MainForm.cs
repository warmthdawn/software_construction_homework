using OrderManager;
using OrderManagerFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OrderFrom
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.sourceOrder.DataSource = OrderService.QueryAll();



            dgvOrderDetail.ClearSelection();
            this.dgvOrderDetail.CellLeave += (s, ev) => dgvOrderDetail.ClearSelection();
            this.dgvOrderDetail.DataBindingComplete += (s, ev) => dgvOrderDetail.ClearSelection();

         }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedOrder(out var o))
            {
                OrderService.DeleteOrder(o.OrderId);
                RefreshList();
            }
            else
            {
                MessageBox.Show("请先选择订单");
            }

        }

        private bool TryGetSelectedOrder(out Order order)
        {

            if (dgvOrder.SelectedRows.Count > 0 && dgvOrder.SelectedRows[0].DataBoundItem is Order o)
            {
                order = o;
                return true;
            }
            order = null;
            return false;
        }

        public void RefreshList()
        {
            this.sourceOrder.DataSource = OrderService.QueryAll();
            this.sourceOrder.ResetBindings(false);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.Filter = "Json 文件 (*.json)|*.json|所有文件|*.*";
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.DefaultExt = ".json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OrderService.Import(ofd.FileName);
                    RefreshList();
                    MessageBox.Show("导入成功");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("导入失败");
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Json 文件 (*.json)|*.json|所有文件|*.*";
            sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.DefaultExt = ".json";
            sfd.OverwritePrompt = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OrderService.Export(sfd.FileName);
                    MessageBox.Show("导出成功");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("导出失败");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedOrder(out var order))
            {
                //编辑要先复制一份
                Order o = new Order(order);
                var form = new NewForm(o);
                form.Text = $"编辑 {o.OrderId}";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    OrderService.EditOrder(o);
                    RefreshList();
                }
            }
            else
            {
                MessageBox.Show("请先选择订单");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            var form = new NewForm(o);
            form.Text = $"添加新订单";
            if (form.ShowDialog() == DialogResult.OK)
            {
                OrderService.AddOrder(o);
                RefreshList();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
