using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Rate
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public double price { get; set; }  // In U$D
        public double percentage_change_24h { get; set; } // 24h %
        public double percentage_change_7d { get; set; }  // & days %
        public double market_cap { get; set; }
        public double volume_24 { get; set; }
        public double circulating_supply { get; set; }

    }
}
