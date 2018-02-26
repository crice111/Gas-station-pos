using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace GasStationPointOfSale
{
    public partial class UpdateGasPrices : Form
    {
        public Form1 f;
        public UpdateGasPrices(Form1 f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] s = { textBox1.Text, textBox2.Text, textBox3.Text };
            for (int i = 0; i < 3; i++)
            {
                var a = new GasPriceDTO();
                a.grade = i;
                a.price = s[i];
                using (var c = new WebClient())
                {
                    c.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    c.UploadString(f.BaseAddress + "/setGasPrice", JsonConvert.SerializeObject(a));
                }
                Close();
            }
        }
    }
}
