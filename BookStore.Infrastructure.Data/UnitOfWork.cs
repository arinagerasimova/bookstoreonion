using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data
{
    class UnitOfWork : IDisposable
    {
        private StoreContext db = new StoreContext();
        private BookRepository bookRepository;
        private OrderRepository orderRepository;
        private PurchaseRepository purchaseRepository;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public PurchaseRepository Purchase
        {
            get
            {
                if (purchaseRepository == null)
                    purchaseRepository = new PurchaseRepository(db);
                return purchaseRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
