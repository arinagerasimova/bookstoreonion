using BookStore.Domain.Core;
using BookStore.Services.Interfaces;

namespace BookStore.Infrastructure.Business
{
    public class CacheOrder : IOrder
    {
        public void MakeOrder(Book book)
        {
            // код покупки книги при оплате наличностью
        }
    }
}
