using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System.Data.Entity;

namespace BookStore.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly StoreContext _db;

        public BookRepository(StoreContext context)
        {
            _db = context;
        }

        public IEnumerable<Book> GetBookList()
        {
            return _db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            return _db.Books.Find(id);
        }

        public void Create(Book book)
        {
            _db.Books.Add(book);
        }

        public void Update(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
                _db.Books.Remove(book);
        }
        
    }
}
