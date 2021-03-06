using System;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class Usd
    {
        [DataMember(EmitDefaultValue = false)]
        public double price { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double volume_24h { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percent_change_1h { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percent_change_24h { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percent_change_7d { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percent_change_30d { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percent_change_60d { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double percent_change_90d { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double market_cap { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double market_cap_dominance { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double fully_diluted_market_cap { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime last_updated { get; set; }

    }
}

