using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoRates.Services.Interfaces
{
    public interface ICMC_Service
    {
        Task<List<Rate>> GetCMCRates();
        
    }
}
