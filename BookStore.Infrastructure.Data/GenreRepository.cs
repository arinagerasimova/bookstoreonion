using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;

namespace BookStore.Infrastructure.Data
{
    public class GenreRepository
    {
        private readonly StoreContext _db;

        public GenreRepository(StoreContext context)
        {
            _db = context;
        }
        public GenreRepository()
        {
            _db=new StoreContext();
        }


        public IQueryable<Genre> FindGenresBy(Expression<Func<Genre, bool>> expression = null)
        {
            if (expression == null)
                return _db.Genres;
            return _db.Genres.Where(expression);
        }

        public IEnumerable<Genre> GetGenreList()
        {
            return _db.Genres.ToList();
        }

        public Genre GetGenre(int id)
        {
            return _db.Genres.Find(id);
        }

        public void Create(Genre genre)
        {
           var result = _db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var genre = _db.Genres.Find(id);
            if (genre != null)
                _db.Genres.Remove(genre);
        }
    }
}
