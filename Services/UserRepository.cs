using Entities;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserRepository : IUser
    {
        private CryptoContext _cryptoContext;
        public UserRepository(CryptoContext cryptoContext)
        {
            _cryptoContext = cryptoContext;
        }

        public IEnumerable<User> GetRates()
        {
            return _cryptoContext.Users;
        }

        public User GetRate(int id)
        {
            return _cryptoContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public void AddRate(User user)
        {
            _cryptoContext.Users.Add(user);
            _cryptoContext.SaveChanges(true);
        }


        public void UpdateRate(User user)
        {
            _cryptoContext.Users.Update(user);
            _cryptoContext.SaveChanges(true);
        }

        public void DeleteRate(int id)
        {
            var user = _cryptoContext.Users.Find(id);
            _cryptoContext.Users.Remove(user);
            _cryptoContext.SaveChanges(true);
        }

    }
}
