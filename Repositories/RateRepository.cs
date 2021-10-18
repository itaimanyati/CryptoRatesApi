using Entities;
using Entities.Models;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class RateRepository : RepositoryBase<Rate>,IRateRepository
    {
        protected readonly ICoinMarketCapAdapter _adapter;
        protected CryptoContext _context;
        public RateRepository(CryptoContext cryptoContext, ICoinMarketCapAdapter adapter) 
            :base(cryptoContext)
        {
            _adapter = adapter;
            _context = cryptoContext;
        }

        public async Task<IEnumerable<Rate>> GetRates()
        {
            var rates =  await _adapter.GetRates();
            return rates;
        }

        public async Task StoreRates()
        {
            var rates = await _adapter.GetRates();
            foreach (var item in rates)
            {
                _context.Add(item);
            }
        }
    }
}
