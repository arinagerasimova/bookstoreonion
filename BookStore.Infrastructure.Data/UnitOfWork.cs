using System;

namespace BookStore.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly StoreContext _db = new StoreContext();
        private BookRepository _bookRepository;
        private OrderRepository _orderRepository;
        private PurchaseRepository _purchaseRepository;

        public BookRepository Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_db);
                return _bookRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_db);
                return _orderRepository;
            }
        }

        public PurchaseRepository Purchase
        {
            get
            {
                if (_purchaseRepository == null)
                    _purchaseRepository = new PurchaseRepository(_db);
                return _purchaseRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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
