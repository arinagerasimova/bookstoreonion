using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Infrastructure.Business.Providers;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Ninject.Modules;
using Ninject;
using BookStore.Util;
using System.Web.Mvc;
using Ninject.Web.Mvc;


[assembly: OwinStartup(typeof(BookStore.Startup))]
namespace BookStore
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}