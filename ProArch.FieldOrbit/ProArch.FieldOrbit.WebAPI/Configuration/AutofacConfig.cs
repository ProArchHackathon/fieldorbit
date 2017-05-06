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
using ProArch.FieldOrbit.BusinessLayer.Services;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.DataLayer.Repositories;
using ProArch.FieldOrbit.DataContracts.Interfaces;

namespace ProArch.FieldOrbit.WebAPI.Configuration
{
    public static class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<LoginOperationsLogic>().As<ILoginOperations>().InstancePerRequest();
            builder.RegisterType<WorkRequestService>().As<IWorkRequestService>().InstancePerRequest();
            builder.RegisterType<WorkRequestRepository>().As<IWorkRequestRepository>().InstancePerRequest();
            builder.RegisterType<ServiceRequestService>().As<IServiceRequestService>().InstancePerRequest();
            builder.RegisterType<ServiceRequestRepository>().As<IServiceRequestRepository>().InstancePerRequest();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}