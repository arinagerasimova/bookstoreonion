using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;

namespace BookStore.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        IEnumerable<Order> GetBookList();
        Order GetBook(int id);
        void Create(Order item);
        void Update(Order item);
        void Delete(int id);

    }
}
