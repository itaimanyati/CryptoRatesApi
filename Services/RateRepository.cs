using Entities;
using Entities.Models;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class RateRepository : IRate
    {
        private RepositoryContext _cryptoContext;
        public RateRepository(RepositoryContext cryptoContext)
        {
            _cryptoContext = cryptoContext;
        }

        public IEnumerable<Rate> GetRates()
        {
            return _cryptoContext.Rates;
        }

        public Rate GetRate(int id)
        {
            var rate = _cryptoContext.Rates.SingleOrDefault(r => r.id == id);
            return rate;
        }

        public void AddRate(Rate rate)
        {
            _cryptoContext.Rates.Add(rate);
            _cryptoContext.SaveChanges(true);
        }
        public void UpdateRate(Rate rate)
        {
            _cryptoContext.Rates.Update(rate);
            _cryptoContext.SaveChanges(true);
        }

    
        public void DeleteRate(int id)
        {
            var rate = _cryptoContext.Rates.Find(id);
            _cryptoContext.Rates.Remove(rate);
            _cryptoContext.SaveChanges(true);
        }

      
    }
}
