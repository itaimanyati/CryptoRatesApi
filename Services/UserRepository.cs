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

        public IEnumerable<User> GetUsers()
        {
            return _cryptoContext.Users;
        }

        public User GetUser(int id)
        {
            return _cryptoContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _cryptoContext.Users.Add(user);
            _cryptoContext.SaveChanges(true);
        }


        public void UpdateUser(User user)
        {
            _cryptoContext.Users.Update(user);
            _cryptoContext.SaveChanges(true);
        }

        public void DeleteUser(int id)
        {
            var user = _cryptoContext.Users.Find(id);
            _cryptoContext.Users.Remove(user);
            _cryptoContext.SaveChanges(true);
        }

    }
}
