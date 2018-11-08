using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System.Data.Entity;

namespace BookStore.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _db;

        public OrderRepository(StoreContext context)
        {
            _db = context;
        }

        public IEnumerable<OrderItem> GetBookList()
        {
            return _db.OrderItems.ToList();
        }

        public OrderItem GetBook(int id)
        {

            return _db.OrderItems.Find(id);
        }

        public void Create(OrderItem order)
        {
            _db.OrderItems.Add(order);
        }

        public void Update(OrderItem order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var order = _db.OrderItems.Find(id);
            if (order != null)
                _db.OrderItems.Remove(order);
        }
    }
}
