using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System.Data.Entity;

namespace BookStore.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private StoreContext db;

        public OrderRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<OrderItem> GetBookList()
        {

            return db.OrderItems.ToList();
        }

        public OrderItem GetBook(int id)
        {

            return db.OrderItems.Find(id);
        }

        public void Create(OrderItem order)
        {
            db.OrderItems.Add(order);
        }

        public void Update(OrderItem order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            OrderItem order = db.OrderItems.Find(id);
            if (order != null)
                db.OrderItems.Remove(order);
        }
    }
}
