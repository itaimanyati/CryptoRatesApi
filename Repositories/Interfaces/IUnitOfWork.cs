using System;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRateRepository Rates { get; }
        IUserRepository Users { get; }
        void Save();
    }
}
