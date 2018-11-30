using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Domain.Core.Model;
using BookStore.Services.Interfaces;

namespace BookStore.Infrastructure.Business.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<User> _userRep;
        private IRepository<Order> _orderRep;
        private IRepository<OrderItem> _orderitemRep;
        private IRepository<Book> _repBook;

        public OrderService(IRepository<User> userRep, IRepository<Order> orderRep, IRepository<OrderItem> orderitemRep, IRepository<Book> repBook)
        {
            _repBook = repBook;
            _userRep = userRep;
            _orderRep = orderRep;
            _orderitemRep = orderitemRep;
        }

        public List<ShortBookModel> OrderBook(string userName)
        {
            if (userName != "")
            {
                var user = _userRep.Get(c => (c.Login == userName)).FirstOrDefault();
                int userId = user.Id;
                var order = _orderRep.Get(c => c.UserId == userId && c.PaymentDate == null).FirstOrDefault();
                if (order == null)
                {
                    return null;
                }
                int orderId = order.Id;
               // return _orderitemRep.Get(c => c.OrderId == orderId).ToList();
                return (from o in _orderitemRep.Get(c => c.OrderId == orderId).ToList()
                    join b in _repBook.Get(c => c.Id > 0).ToList() on o.BookId equals b.Id
                    select new ShortBookModel()
                        { Id = b.Id, Author = b.Author.AuthorName, Price = b.Price, Title = b.Title }).ToList();
            }
            return null;
        }

        public int NumberOfBook(string userName)
        {
            if (userName != "")
            {
                var user = _userRep.Get(c => (c.Login == userName)).FirstOrDefault();
                int userId = user.Id;
                var order = _orderRep.Get(c => c.UserId == userId && c.PaymentDate == null).FirstOrDefault();
                if (order == null)
                {
                    return 0;
                }
                int orderId = order.Id;
                return _orderitemRep.Get(c => c.OrderId == orderId).ToList().Count();
                
            }
            return 0;
        }

        public void BookOrder(int idBook, string userName)
        {
            var user = _userRep.Get(c => (c.Login == userName)).FirstOrDefault();

            int userId = user.Id;
            var order = _orderRep.Get(c => c.UserId == userId && c.PaymentDate == null).FirstOrDefault();
            if (order == null)
            {
                order = new Order() { UserId = userId };
                _orderRep.Create(order);
            }
            int orderId = order.Id;
            var orderItems = new OrderItem() { BookId = idBook, OrderId = orderId };
            _orderitemRep.Create(orderItems);
        }

        public void Buy(string userName)
        {
            var user = _userRep.Get().SingleOrDefault(c => c.UserName == userName);
            if (user != null)
            {
                //todo log 4 net 
            }
            int userId = user.Id;

            var order = _orderRep.Get().SingleOrDefault(c => c.UserId == userId && c.PaymentDate == null);
            if (order != null)
            {
                order.PaymentDate = DateTime.Now;
                _orderRep.Update(order);
            }

        }
    }
}
