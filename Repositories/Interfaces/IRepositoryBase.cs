using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories
{
    public interface IRepositoryBase<T> where T : class
        
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
