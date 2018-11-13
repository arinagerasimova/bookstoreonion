using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Business.Model;

namespace BookStore.Services.Interfaces
{
    public interface IBookService
    {
        List<GenreItem> GetGanre();
    }
}
