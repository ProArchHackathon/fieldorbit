using ProArch.FieldOrbit.WebAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ProArch.FieldOrbit.WebAPI.App_Start;

namespace ProArch.FieldOrbit.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.Initialize();
            AutoMapperConfig.Configure();
        }
    }
}
