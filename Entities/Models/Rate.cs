using System;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class Rate
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
        public double price { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percentage_change_24h { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percentage_change_7d { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double market_cap { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double volume_24 { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double circulating_supply { get; set; }
       

    }
}
