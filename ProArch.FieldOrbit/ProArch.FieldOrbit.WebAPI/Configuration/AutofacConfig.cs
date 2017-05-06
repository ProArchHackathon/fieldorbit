using Autofac;
using Autofac.Integration.WebApi;
using ProArch.FieldOrbit.BusinessLayer.Security;
using ProArch.FieldOrbit.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ProArch.FieldOrbit.WebAPI.Configuration
{
    public static class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<LoginOperationsLogic>().As<ILoginOperations>().InstancePerRequest();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}