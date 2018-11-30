using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Domain.Core;
using BookStore.Domain.Core.Model;
using BookStore.Domain.Interfaces;
using BookStore.Services.Interfaces;
using BookStore.Infrastructure.Business.Model;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Business.Services
{
    public class BookService : IBookService
    {
        private IRepository<Genre> _repGenre;
        private IRepository<Book> _repBook;

        public BookService(IRepository<Genre> repGenre, IRepository<Book> repBook)
        {
            _repGenre = repGenre;//new Repository<Genre>(); 
            _repBook = repBook;// new Repository<Book>();
        }

        public List<GenreItem> GetGanre()
        {
            var genres = _repGenre.Get().Select(x => new GenreItem
            {
                Id = x.Id,
                GenreName = x.Genre1
            }).ToList();
            return genres;
        }
        public List<ShortBookModel> GetBooks(string genreName)
        {
            List<ShortBookModel> books;
            if (genreName == null)
            {
                books = _repBook.Get().Select(x => new ShortBookModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author.AuthorName,
                    Price = x.Price

                }).ToList();
                return books;
            }
             books = _repBook.Get(c=>c.Genre.Genre1==genreName).Select(x => new ShortBookModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author.AuthorName,
                Price = x.Price

            }).ToList();
            return books;



        }

    }
}
