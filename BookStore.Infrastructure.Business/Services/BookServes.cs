using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;
using BookStore.Services.Interfaces;
using BookStore.Infrastructure.Business.Model;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Business
{
    public class BookServes:IBookServes
    {
        public static List<GenerItem> GetGanre()
        {
            GenreRepository g=new GenreRepository();
            var genres = g.FindGenresBy().Select(x=>new GenerItem
            {
                Id = x.Id,
                GenreName = x.Genre1
            }).ToList();

            return genres;
        }

    }
}
