
using System.Web.Http;
using BookStore.Infrastructure.Business;
using BookStore.Infrastructure.Business.Services;
using BookStore.Services.Interfaces;
using Microsoft.Owin.Security.Provider;

namespace BookStore.Controllers
{
    [System.Web.Http.AllowAnonymous]
    [System.Web.Http.Route("api/home")]
    public class HomeController : ApiController
    {
            ////[System.Web.Http.Authorize]
            [System.Web.Http.HttpGet]
            public IHttpActionResult Get()
            {
                IBookService b =new BookService();
                
                return Ok(b.GetGanre());
            }
    }
}