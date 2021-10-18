using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICoinMarketCapAdapter
    {
        Task<List<Rate>> GetRates();
    }
}
