using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace GasStationPointOfSale
{
    public partial class Pay : Form
    {
        public Form1 f;

        public Pay(Form1 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentDTO pay = new PaymentDTO();
            pay.cc = textBox1.Text;
            List<ItemDTO> items = new List<ItemDTO>();
            foreach (var i in f.Items())
            {
                Item item = (Item)i;
                decimal cost = item.Cost;
                if (item.Taxed)
                {
                    cost = (f.TaxRate * cost) + cost;
                }
                items.Add(new ItemDTO(item.Name, cost));
            }
            pay.items = items.ToArray();
            string json = JsonConvert.SerializeObject(pay);
            using (var c = new WebClient())
            {
                c.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                c.UploadString(f.BaseAddress + "/doTransaction", json);
            }
            f.reset();
            Close();
        }
    }
}
