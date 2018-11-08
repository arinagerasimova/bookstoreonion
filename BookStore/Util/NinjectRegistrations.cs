using System.Web;
using Ninject.Modules;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Business;
using BookStore.Infrastructure.Business.Services;
using BookStore.Infrastructure.Business.Services.Interfaces;
using BookStore.Infrastructure.Data;
using BookStore.Services.Interfaces;

namespace BookStore.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookRepository>().To<BookRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IPurchaseRepository>().To<PurchaseRepository>();
            Bind<IOrderService>().To<OrderService>();
        }
    }
}