using System;
using System.Collections.Generic;
using BookStore.Domain.Core;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBookList();
        Book GetBook(int id);
        void Create(Book item);
        void Update(Book item);
        void Delete(int id);
    }
}
