using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using BookStore.Services.Interfaces;
using AutoMapper;
using BookStore.Domain.Core.Model;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        IBookRepository repo;
        IOrder order;
        IPurchaseRepository part;

        public HomeController(IBookRepository r, IOrder o, IPurchaseRepository p)
        {
            repo = r;
            order = o;
            part = p;
        }

        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Book, ShortBookModel>());
            // сопоставление
            var users =
                Mapper.Map<IEnumerable<Book>, List<ShortBookModel>>(repo.GetBookList());
            return View(users);
        }
        
    }
}