using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;

namespace BookStore.Infrastructure.Data
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly StoreContext _db;

        public PurchaseRepository(StoreContext context)
        {
            _db = context;
        }

        public IEnumerable<Order> GetBookList()
        {
            return _db.Orders.ToList();
        }

        public Order GetBook(int id)
        {
            return _db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            _db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var order = _db.Orders.Find(id);
            if (order != null)
                _db.Orders.Remove(order);
        }
    }
}
