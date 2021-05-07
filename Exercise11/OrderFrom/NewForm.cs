using OrderManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderFrom
{
    public partial class NewForm : Form
    {
        public NewForm(Order order)
        {
            this._order = order;
            InitializeComponent();
        }


        private Order _order;
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NewForm_Load(object sender, EventArgs e)
        {
            this.sourceOrder.DataSource = _order;
        }
    }
}
