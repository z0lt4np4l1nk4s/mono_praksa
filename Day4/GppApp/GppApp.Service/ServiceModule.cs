using Autofac;
using GppApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GppApp.Service
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CustomerService>().As<ICustomerService>();
            //builder.RegisterType<LocationService>().As<ILocationService>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            var k = builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(x => x.Name == "I" + t.Name));
        }
    }
}
