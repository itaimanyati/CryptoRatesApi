using System;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class Platform
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
        public string token_address { get; set; }
    }
}
