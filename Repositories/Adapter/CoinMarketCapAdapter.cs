using Entities.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Repositories.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class CoinMarketCapAdapter : ICoinMarketCapAdapter
    {
        private readonly IConfiguration _config;
        private List<Rate> ratesList;

        public CoinMarketCapAdapter()
        {
        }

        public CoinMarketCapAdapter(IConfiguration config)
        {
            _config = config;
            ratesList = new List<Rate>();
        }
        public async Task<List<Rate>> GetRates()
        {
            var result = new Rate();
            try
            {

                var client = new RestClient("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest")
                {
                    Timeout = -1,
                    FollowRedirects = true
                };

                var request = new RestRequest(Method.GET);

                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("X-CMC_PRO_API_KEY", _config["CMC_API_KEY"]);
                request.AddHeader("Accepts", "application/json");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                if (response.IsSuccessful == true)
                {

                    dynamic primaryResult = JObject.Parse(response.Content);
                    //var statusStr = primaryResult["data"];
                    foreach (var coin in primaryResult["data"])
                    {
                        // Create Rate object 

                        var coinObj = new Rate() {
                            id = coin.id,
                            name = coin.name,
                            symbol = coin.symbol,
                            slug = coin.slug,
                            price = coin.quote.USD.price,
                            percentage_change_24h = coin.quote.USD.percent_change_24h,
                            percentage_change_7d = coin.quote.USD.percent_change_7d,
                            market_cap = coin.quote.USD.market_cap,
                            circulating_supply = coin.circulating_supply

                        };

                        ratesList.Add(coinObj);

                    }
                        

                }

            }

            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message);


            }

            return ratesList;

        }

        
    }

}
