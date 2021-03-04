using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double left;
            double right;
            if (!double.TryParse(txtLeft.Text, out left))
            {
                txtResult.Text = "输入的内容不是数字！";
                return;
            }
            if (!double.TryParse(txtRight.Text, out right))
            {
                txtResult.Text = "输入的内容不是数字！";
                return;
            }

            switch (cmbOperator.SelectedItem)
            {
                case "+":
                    txtResult.Text = $"{left} + {right} = {left + right}";
                    break;

                case "-":
                    txtResult.Text = $"{left} - {right} = {left - right}";
                    break;

                case "*":
                    txtResult.Text = $"{left} * {right} = {left * right}";
                    break;

                case "/":
                    txtResult.Text = $"{left} / {right} = {left / right}";
                    break;

            }


        }

    }
}
