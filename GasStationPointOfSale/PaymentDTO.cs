using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GasStationPointOfSale
{
    class PaymentDTO
    {
        public string cc { get; set; }
        public ItemDTO[] items { get; set; }

    }
}
