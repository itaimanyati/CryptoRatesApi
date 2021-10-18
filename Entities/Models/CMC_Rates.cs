using Newtonsoft.Json;
using System.Collections.Generic;


namespace Entities.Models
{
    public class CMC_Rates
    {
        [JsonConverter(typeof(RatesConverter))]
        public List<Data> data { get; set; }
    }
}
