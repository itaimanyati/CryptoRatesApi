using System;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class Status
    {
        [DataMember(EmitDefaultValue = false)]
        public DateTime timestamp { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int error_code { get; set; }
        [DataMember(EmitDefaultValue = false)]

        public string error_message { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int elapsed { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int credit_count { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string notice { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int total_count { get; set; }
    }
}
