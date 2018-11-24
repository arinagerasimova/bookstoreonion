using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace BookStore.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        StoreContext _context;
        DbSet<T> _dbSet;

        public Repository(StoreContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Repository()
        {
            _context = new StoreContext();
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Get(Expression< Func<T, bool>> expression = null)
        {
            //return _dbSet.AsNoTracking().Where(predicate);
            if (expression == null)
                return _dbSet;
            return _dbSet.Where(expression);
        }

        public T FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
                _context.SaveChanges();
            

        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

    }
}
