using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System.Data.Entity;

namespace BookStore.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private StoreContext db;

        public BookRepository()
        {
            this.db = new StoreContext();
        }

        public IEnumerable<Book> GetBookList()
        {
            return db.Book.ToList();
        }

        public Book GetBook(int id)
        {
            return db.Book.Find(id);
        }

        public void Create(Book book)
        {
            db.Book.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = db.Book.Find(id);
            if (book != null)
                db.Book.Remove(book);
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
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
