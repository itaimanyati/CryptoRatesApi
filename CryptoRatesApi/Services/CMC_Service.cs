
using CryptoRates.Services.Interfaces;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CMC_Service : ICMC_Service
    {
        
        private readonly ICoinMarketCapAdapter _adapter;
        public CMC_Service(IConfiguration config, ICoinMarketCapAdapter adapter)
        {
          
            _adapter = adapter;
        }
        public async Task<List<Rate>> GetCMCRates()
        {

            var response = await _adapter.GetRates();

            return response;
        }


    }
}
