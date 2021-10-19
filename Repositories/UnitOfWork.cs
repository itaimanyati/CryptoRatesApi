using Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CryptoContext _context;
        private readonly ICoinMarketCapAdapter _adapter;
     
        public UnitOfWork(CryptoContext cryptoContext, ICoinMarketCapAdapter adapter)
        {
            _context = cryptoContext;
            _adapter = adapter;
            Adapter = new CoinMarketCapAdapter();
            Rates = new RateRepository(_context, _adapter);
                    
        }

        public ICoinMarketCapAdapter Adapter { get; set; }
        public IRateRepository Rates { get; set; }


        public void Save()
        {
            _context.SaveChanges();
        }

    
        public void Dispose()
        {
            _context.Dispose();
            
        }
    }
}
