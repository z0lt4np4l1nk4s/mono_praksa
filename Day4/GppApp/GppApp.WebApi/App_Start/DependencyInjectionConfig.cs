using Autofac.Integration.WebApi;
using Autofac;
using GppApp.Service.Common;
using GppApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using GppApp.Repository;

namespace GppApp.WebApi.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();


            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new RepositoryModule());

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}