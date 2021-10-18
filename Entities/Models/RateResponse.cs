using System;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [Serializable]
    [DataContract]
    public class RateResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public Status status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Data data { get; set; }

    }
}
