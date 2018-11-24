
using System.Web.Http;
using BookStore.Infrastructure.Business;
using BookStore.Infrastructure.Business.Services;
using BookStore.Services.Interfaces;
using Microsoft.Owin.Security.Provider;

namespace BookStore.Controllers
{
    [System.Web.Http.AllowAnonymous]
    public class HomeController : ApiController
    {
        private IBookService b;

        public HomeController(IBookService bookService)
        {
            b = bookService;
        }

        [Route("api/genre")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetGanre()
        {

            return Ok(b.GetGanre());
        }

        [Route("api/bookset")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetBookSet()
        {

            return Ok(b.GetBooks());
        }
    }
}