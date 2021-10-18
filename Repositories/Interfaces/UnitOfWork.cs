using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CryptoContext _context;
        public UnitOfWork(CryptoContext cryptoContext)
        {
            _context = cryptoContext;
            Rates = new RateRepository(_context);
            Users = new UserRepository(_context);
        }
        public IRateRepository Rates { get; private set; }
        public IUserRepository Users { get; private set; }


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
