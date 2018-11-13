using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Business.Model
{
    public class GenerItem
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public GenerItem()
        {
        }

        public GenerItem(int id, string name)
        {
            Id = id;
            GenreName = name;
        }

    }
}
