using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext _context;

        public RepositoryBase(CryptoContext repositoryContext)
        {
            _context = repositoryContext;
        }


        // Get entity
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        // Return all 
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();

        }

        // Get type by specified condition e.g. id 
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }


        // Add entities
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
           
        }

           

        // Update changes
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
    
        }

        // Delete entity
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
         
        }

    }
}
