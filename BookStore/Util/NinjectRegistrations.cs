using System.Web;
using BookStore.Domain.Core;
using Ninject.Modules;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Business;
using BookStore.Infrastructure.Business.Services;
using BookStore.Infrastructure.Data;
using BookStore.Services.Interfaces;

namespace BookStore.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Book>>().To<Repository<Book>>();
            Bind<IRepository<Genre>>().To<Repository<Genre>>();
            Bind<IBookService>().To<BookService>();
            //Bind<IPurchaseRepository>().To<PurchaseRepository>();
        }
    }
}