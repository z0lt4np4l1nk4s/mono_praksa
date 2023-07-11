using Autofac;
using GppApp.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Repository
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            //builder.RegisterType<LocationRepository>().As<ILocationRepository>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            var k = builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .As(t => t.GetInterfaces().FirstOrDefault(x => x.Name == "I" + t.Name));
        }
    }
}
