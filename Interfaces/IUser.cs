using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void AddUser(User rate);
        void UpdateUser(User rate);
        void DeleteUser(int id);
    }
}
