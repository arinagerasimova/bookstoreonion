using System;
using System.Collections.Generic;
using BookStore.Domain.Core;

namespace BookStore.Domain.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<OrderItem> GetBookList();
        void Create(OrderItem item);
        void Delete(int id);
    }
}
