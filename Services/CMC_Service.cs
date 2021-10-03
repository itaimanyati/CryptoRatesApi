using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
    public class CMC_Service
    {
        public static async Task<object> GetCMCRates()
        {

            var client = new HttpClient();
            string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

            //Append CMC specific headers
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "48458c6a-b6f7-4b5e-9a86-2c2e1df4496b");
            client.DefaultRequestHeaders.Add("Accepts", "application/json");

            var response = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject(response);


        }
    }
}
