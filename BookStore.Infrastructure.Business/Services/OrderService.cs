using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System;
using System.Linq;

namespace BookStore.Infrastructure.Business.Services
{
    public class OrderService
    {
        private IRepository<User> _userRep;
        private IRepository<Order> _orderRep;
        private IRepository<OrderItems> _orderitemRep;

        public OrderService(IRepository<User> userRep, IRepository<Order> orderRep, IRepository<OrderItems> orderitemRep)
        {
            _userRep = userRep;
            _orderRep = orderRep;
            _orderitemRep = orderitemRep;
        }

        public void BookOrder(int idBook, string userName)
        {
            var user = _userRep.Get().SingleOrDefault(c => c.UserName == userName);
            if (user == null)
            {
                //todo log 4 net 
            }
            int userId = user.Id;
            var order = _orderRep.Get().SingleOrDefault(c => c.UserId == userId && c.PaymentDate == null);
            if (order == null)
            {
                order = new Order() { UserId = userId };
                _orderRep.Create(order);
            }
            int orderId = order.Id;
            var orderItems = new OrderItems() { BookId = idBook, OrderId = orderId };
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
