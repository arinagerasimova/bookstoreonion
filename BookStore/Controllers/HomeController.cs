
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

        //[System.Web.Http.Authorize]
        [Route("")]
        [System.Web.Http.HttpGet]

            public IHttpActionResult Get()
            {
                IBookService b =new BookService();
                
                return Ok(b.GetGanre());
            }
    }
}