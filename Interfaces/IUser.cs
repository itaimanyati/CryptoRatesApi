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
        IEnumerable<User> GetRates();
        User GetRate(int id);
        void AddRate(User rate);
        void UpdateRate(User rate);
        void DeleteRate(int id);
    }
}
