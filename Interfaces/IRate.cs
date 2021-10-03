using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRate
    {
        IEnumerable<User> GetRates();
        Rate GetRate (int id);
        void AddRate(User user);
        void UpdateRate(User user);
        void DeleteRate(int id);

    }
}
