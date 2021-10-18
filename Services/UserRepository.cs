using Entities;
using Entities.Models;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserRepository : IUser
    {
        private RepositoryContext _cryptoContext;
        public UserRepository(RepositoryContext cryptoContext)
        {
            _cryptoContext = cryptoContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _cryptoContext.Users;
        }

        public User GetUser(int id)
        {
            return _cryptoContext.Users.SingleOrDefault(u => u.id == id);
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
