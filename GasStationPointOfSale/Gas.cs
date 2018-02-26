using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace GasStationPointOfSale
{
    public partial class Gas : Form
    {
        public Form1 f;
        public static string[] grades = { "Regular", "Plus", "Premium" };
        public Gas(Form1 f)
        {
            this.f = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyValuePair<string, decimal> kv = (KeyValuePair<string, decimal>)comboBox1.SelectedItem;
            f.AddItemToTotal(new Item(string.Format("Gas - {0}", kv.Value.ToString("C")), kv.Value * Decimal.Parse(textBox1.Text), true));
            DispenseGasDTO d = new DispenseGasDTO();
            d.pump = int.Parse(textBox2.Text);
            d.gallons = decimal.Parse(textBox1.Text);
            d.grade = Array.IndexOf(grades, kv.Key);
            string json = JsonConvert.SerializeObject(d);
            string resp_json_string = string.Empty;
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                try
                {
                    resp_json_string = client.UploadString(f.BaseAddress + "/dispenseGas", json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            var resp = false;
            try
            {
                resp = (bool) JsonConvert.DeserializeObject(resp_json_string);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!resp)
            {
                MessageBox.Show("Server Error", "Server returned false.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void Gas_Load(object sender, EventArgs e)
        {
            using (var c = new WebClient())
            {
                string s = string.Empty;
                try
                {
                    s = c.DownloadString(f.BaseAddress + "/getGasPrices");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                double[] prices = new double[3];
                try
                {
                    prices = JsonConvert.DeserializeObject<double[]>(s);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                comboBox1.Items.Add(new KeyValuePair<string, decimal>(grades[0], new decimal(prices[0])));
                comboBox1.Items.Add(new KeyValuePair<string, decimal>(grades[1], new decimal(prices[1])));
                comboBox1.Items.Add(new KeyValuePair<string, decimal>(grades[2], new decimal(prices[2])));
            }
            


        }
    }
}
