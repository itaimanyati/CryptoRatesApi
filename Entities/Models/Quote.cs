using System;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class Quote
    {
        [DataMember(EmitDefaultValue = false)]
        public Usd USD { get; set; }
    }
}
