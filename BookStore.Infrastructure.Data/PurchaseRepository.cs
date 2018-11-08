using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;

namespace BookStore.Infrastructure.Data
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private StoreContext db;

        public PurchaseRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetBookList()
        {

            return db.Orders.ToList();
        }

        public Order GetBook(int id)
        {

            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }

    }
}
