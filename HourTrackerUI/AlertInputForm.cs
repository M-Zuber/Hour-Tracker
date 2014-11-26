using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HourTrackerUI
{
    public partial class AlertInputForm : Form
    {
        public string InputText { get; set; }

        public AlertInputForm(string description)
        {
            InitializeComponent();

            this.inputDescription.Text = description;

            this.inputDescription.Left = 5;
            this.input.Left = this.inputDescription.Right + 5;
            this.confirm.Left = this.input.Right + 5;
            this.Width += 10;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(input.Text))
            {
                this.inputDescription.Text = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("The text for \"" + this.inputDescription.Text + "\" can not be empty",
                                "Error...",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            this.InputText = this.input.Text;
        }
    }
}
