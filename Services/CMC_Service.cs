using Entities.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Services
{
    public class CMC_Service
    {
        public static async Task<CMC_Rates> GetCMCRates()
        {

            var client = new HttpClient();
            string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest";

            //Append CMC specific headers
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", Environment.GetEnvironmentVariable("CMC_API_KEY"));
            client.DefaultRequestHeaders.Add("Accepts", "application/json");

            var response = await client.GetFromJsonAsync<CMC_Rates>(url);
                       
            return response;
               
        }
    }
}
