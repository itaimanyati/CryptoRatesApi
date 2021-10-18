using Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CryptoContext _context;
        public UnitOfWork(CryptoContext cryptoContext)
        {
            _context = cryptoContext;
            //Rates = new RateRepository();
           
        }
        public IRateRepository Rates { get; private set; }
        
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
