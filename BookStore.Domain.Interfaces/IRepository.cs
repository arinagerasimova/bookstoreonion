using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookStore.Domain.Core;
using BookStore.Infrastructure.Business.Model;

namespace BookStore.Domain.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        IQueryable<T> Get(Expression<Func<T, bool>> expression = null);
        T FindById(int id);
        void Create(T item);
        void Remove(T item);
        void Update(T item);
       
    }
}
