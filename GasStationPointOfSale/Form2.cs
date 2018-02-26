using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GasStationPointOfSale
{
    public partial class Form2 : Form
    {
        public Form1 f;

        public Form2(Form1 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            if (!string.IsNullOrEmpty(maskedTextBox1.Text) && maskedTextBox1.Text.Length > 5)
            {
                f.AddItemToTotal(new Item("Flag", new decimal(1337.42), false));
            } else
            {
                MessageBox.Show("Invalid Password", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
             
        }
    }
}
