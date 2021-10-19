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
        //protected readonly CryptoContext _context;
        public RateRepository(CryptoContext cryptoContext) 
            :base(cryptoContext)
        {
           
        }

     

       
    }
}
