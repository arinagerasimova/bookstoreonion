using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;

namespace BookStore.Services.Interfaces
{
    public interface IOrderService
    {
        void BookOrder(int idBook, string userName);
         int NumberOfBook(string userName);
        void Buy(string userName);
    }
}
