using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using System;
using System.Linq;
using BookStore.Services.Interfaces;

namespace BookStore.Infrastructure.Business.Services
{
    public class OrderService: IOrderService
    {
        private IRepository<User> _userRep;
        private IRepository<Order> _orderRep;
        private IRepository<OrderItem> _orderitemRep;

        public OrderService(IRepository<User> userRep, IRepository<Order> orderRep, IRepository<OrderItem> orderitemRep)
        {
            _userRep = userRep;
            _orderRep = orderRep;
            _orderitemRep = orderitemRep;
        }

        public void BookOrder(int idBook, string userName)
        {
            var user = _userRep.Get(c => (c.Login == userName)).FirstOrDefault();
            if (user!=null)
            {
                //todo log 4 net 
            }
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
