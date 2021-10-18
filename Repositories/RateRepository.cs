using Entities;
using Entities.Models;

namespace Repositories
{
    public class RateRepository : RepositoryBase<Rate>,IRateRepository
    {  
        public RateRepository(CryptoContext cryptoContext) :base(cryptoContext)
        {
            
        }
  
    }
}
