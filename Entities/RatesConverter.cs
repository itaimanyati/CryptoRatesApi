using Entities.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RatesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(CMC_Rates);

        // Read from JSON to C# object
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var response = new List<Data>();

            JObject data = JObject.Load(reader);

            foreach (var item in data)
            {
                var d = JsonConvert.DeserializeObject<Data>(item.Value.ToString());
               
                response.Add(d);
            }

            return response;
        }


        // Converting the Rate objects to JSON format
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            writer.WriteStartArray();
            foreach (var rate in (List<Data>)value)
            {
                writer.WriteRawValue(JsonConvert.SerializeObject(rate));
            }
            writer.WriteEndArray();
        }
    }
}
