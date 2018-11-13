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
    public class BookService:IBookService
    {
        private IRepository<Genre> _repository;

        public BookService()
        {
            _repository = new Repository<Genre>();
        }

        public List<GenreItem> GetGanre()
        {
            var genres = _repository.Get().Select(x => new GenreItem
            {
                Id = x.Id,
                GenreName = x.Genre1
            }).ToList();
            return genres;
        }


    }
}
