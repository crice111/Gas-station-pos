using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GasStationPointOfSale
{
    class ItemDTO
    {
        public string description { get; set; }
        public decimal price { get; set; }

        public ItemDTO() { }

        public ItemDTO(string d, decimal p)
        {
            description = d;
            price = p;
        }
    }




}
