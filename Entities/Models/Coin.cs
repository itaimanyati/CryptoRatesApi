using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class Coin
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string symbol { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string slug { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int num_market_pairs { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime date_added { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<string> tags { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public long max_supply { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double circulating_supply { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double total_supply { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Platform platform { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int cmc_rank { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime last_updated { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Quote quote { get; set; }
    }
}
