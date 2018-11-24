using BookStore.Domain.Core;
using Ninject.Modules;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Business;
using BookStore.Infrastructure.Business.Services;
using BookStore.Infrastructure.Data;
using BookStore.Services.Interfaces;
using Ninject;

namespace BookStore.Util
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Create the bindings
            kernel.Bind<IRepository<Book>>().To<Repository<Book>>();
            kernel.Bind<IRepository<Genre>>().To<Repository<Genre>>();
            kernel.Bind<IRepository<User>>().To<Repository<User>>();
            kernel.Bind<IRepository<Order>>().To<Repository<Order>>();
            kernel.Bind<IRepository<OrderItem>>().To<Repository<OrderItem>>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IBookService>().To<BookService>();
            
            return kernel;
        }
    }
}