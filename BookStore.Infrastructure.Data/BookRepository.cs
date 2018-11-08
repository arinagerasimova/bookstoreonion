using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System.Data.Entity;
using AutoMapper;
using BookStore.Domain.Core.Model;

namespace BookStore.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private StoreContext db;

        public BookRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetBookList()
        {
           
            return db.Books.ToList();
        }

        public Book GetBook(int id)
        {
            
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
        
    }
}
