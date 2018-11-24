using BookStore.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore.Domain.Core.Model;

namespace BookStore.Controllers
{
    //[RoutePrefix("api/Orders")]

    public class OrdersController : ApiController
    {

        private IOrderService order;

        public OrdersController(IOrderService orderService)
        {
            var name = User.Identity.Name;
            order = orderService;
        }

        [Authorize]
        [Route("api/orders/create")]
        public async Task<IHttpActionResult> CreateOrder(OrderBook book)
        {
            var name = User.Identity.Name;
            order.BookOrder(book.IdBook, name);
            return Ok();
        }
    }


}


