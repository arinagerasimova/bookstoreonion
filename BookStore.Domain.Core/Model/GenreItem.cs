using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Business.Model
{
    public class GenreItem
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public GenreItem()
        {
        }

        public GenreItem(int id, string name)
        {
            Id = id;
            GenreName = name;
        }

    }
}
