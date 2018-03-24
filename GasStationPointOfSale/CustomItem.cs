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
            double price = decimal.Parse(textBox2.Text);            //Changed to ensure price is more than 0 on custom items
            if(price>=0){
            Item i = new Item(textBox1.Text, price, checkBox1.Checked);
            form.AddItemToTotal(i);
            }
            Close();
        }
    }
}
