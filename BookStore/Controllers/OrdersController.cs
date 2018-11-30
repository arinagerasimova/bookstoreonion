using BookStore.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore.Domain.Core.Model;

namespace BookStore.Controllers
{
    [RoutePrefix("api/Orders")]

    public class OrdersController : ApiController
    {

        private IOrderService order;

        public OrdersController(IOrderService orderService)
        {
            var name = User.Identity.Name;
            order = orderService;
        }

        [Authorize]
        [Route("create")]
        public async Task<IHttpActionResult> CreateOrder(OrderBook book)
        {
            var name = User.Identity.Name;
            order.BookOrder(book.IdBook, name);
            return Ok();
        }

        [Authorize]
        [Route("items")]
        public async Task<IHttpActionResult> GetOrderBook(OrderBook book)
        {
            var name = User.Identity.Name;
            var q = order.OrderBook(name);
            return Ok(q);
        }

        [Route("count")]
        [AllowAnonymous]
        public string GetNumberOfBook()
        {
            var name = User.Identity.Name;
            var count=order.NumberOfBook(name);
            if (count == 0)
                return "";
            return count.ToString();
        }



    }


}


