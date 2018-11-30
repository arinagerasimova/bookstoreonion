using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Core;
using BookStore.Domain.Core.Model;

namespace BookStore.Services.Interfaces
{
    public interface IOrderService
    {
        void BookOrder(int idBook, string userName);
         int NumberOfBook(string userName);
        void Buy(string userName);
        List<ShortBookModel> OrderBook(string userName);
    }
}
