using BookStore.Domain.Core;

namespace BookStore.Services.Interfaces
{
    public interface IOrder
    {
        void MakeOrder(Book book);
    }
}
