using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class Data
    {
        [DataMember(EmitDefaultValue = false)]
        public List<Coin> Coins { get; set; }
    }
}
