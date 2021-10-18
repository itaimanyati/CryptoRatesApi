using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {

        public UserRepository(CryptoContext cryptoContext) :base(cryptoContext)
        {
          
        }

        
    }
}
