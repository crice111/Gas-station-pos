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
    public partial class CustomItem : Form
    {
        public Form1 form;

        public CustomItem(Form1 form1)
        {
            form = form1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item i = new Item(textBox1.Text, decimal.Parse(textBox2.Text), checkBox1.Checked);
            form.AddItemToTotal(i);
            Close();
        }
    }
}
