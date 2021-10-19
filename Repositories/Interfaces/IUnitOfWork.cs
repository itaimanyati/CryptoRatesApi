using System;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRateRepository Rates { get; set; }
        ICoinMarketCapAdapter Adapter { get; set; }
        void Save();
    }
}
