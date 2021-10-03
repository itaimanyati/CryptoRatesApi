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
        IEnumerable<Rate> GetRates();
        Rate GetRate (int id);
        void AddRate(Rate rate);
        void UpdateRate(Rate rate);
        void DeleteRate(int id);

    }
}
