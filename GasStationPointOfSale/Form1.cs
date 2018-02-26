using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GasStationPointOfSale
{
    public partial class Form1 : Form
    {
        public decimal SubTotal = 0;
        public decimal Tax = 0;
        public decimal TaxRate = new decimal(0.07);
        public decimal Total = 0;
        public string BaseAddress = File.ReadAllLines(@"C:\config.txt").First();

        public Form1()
        {
            InitializeComponent();
        }

        public ListBox.ObjectCollection Items()
        {
            return listBox1.Items;
        }

        public void AddItemToTotal(Item i)
        {
            SubTotal += i.Cost;
            if (i.Taxed)
            {
                Tax += TaxRate * i.Cost;
            }
            Total = (TaxRate * i.Cost) + i.Cost;
            listBox1.Items.Add(i);
            textBox1.Text = SubTotal.ToString("C");
            textBox2.Text = Tax.ToString("C");
            textBox3.Text = (Tax + SubTotal).ToString("C");
            button3.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(1.85), true));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(3.99), true));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(12.99), true));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(5.99), true));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(0.99), true));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(1.39), true));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(1.69), true));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(0.42), true));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(1.37), true));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(1.57), true));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(1.87), true));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Text;
            AddItemToTotal(new Item(name, new decimal(1.87), true));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CustomItem i = new CustomItem(this);
            i.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Should require supvisior perms
            reset();
        }

        public void reset()
        {
            SubTotal = 0;
            Tax = 0;
            Total = 0;
            listBox1.Items.Clear();
            textBox1.Text = "$0.00";
            textBox2.Text = "$0.00";
            textBox3.Text = "$0.00";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var a = new Pay(this);
            a.ShowDialog(this);
            a.TopMost = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Needs permission from supervisiors to return to normal operation
            reset();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Item li = (Item) listBox1.Items[listBox1.Items.Count - 1];
            SubTotal = SubTotal - li.Cost;
            Total = Total - li.Cost;
            if (li.Taxed)
            {
                Total = Total - (li.Cost * TaxRate);
                Tax = Tax - (li.Cost * TaxRate);
            }
            textBox1.Text = SubTotal.ToString("C");
            textBox2.Text = Tax.ToString("C");
            textBox3.Text = (Tax + SubTotal).ToString("C");
            listBox1.Items.Remove(li);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gas g = new Gas(this);
            g.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form2(this);
            f.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var f = new UpdateGasPrices(this);
            f.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateGasPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new UpdateGasPrices(this);
            f.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        // This **should** be removed
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void addFlagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItemToTotal(new Item("Flag", new decimal(1337.42), false));
        }

        private void blueFlagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\System32");
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"chrome", @"w:\transactions.html");
        }
    }
}
