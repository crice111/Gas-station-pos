using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GasStationPointOfSale
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool Taxed { get; set; }

        public Item(string Name, decimal Cost, bool Taxed)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Taxed = Taxed;
        }

        public override string ToString()
        {
            string tax = string.Empty;
            if (Taxed)
            {
                tax = "T";
            }
            return string.Format("{0} ({1}) {2}", Name, Cost, tax);
        }
    }
}
