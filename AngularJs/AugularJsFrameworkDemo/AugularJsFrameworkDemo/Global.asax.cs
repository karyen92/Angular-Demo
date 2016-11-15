using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AugularJsFrameworkDemo.Areas.Form;
using AugularJsFrameworkDemo.Areas.Students;
using Castle.Windsor;

namespace AugularJsFrameworkDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StudentsAreaBundleConfig.RegisterBundles(BundleTable.Bundles);
            FormAreaBundleConfig.RegisterBundles(BundleTable.Bundles);
            ContainerConfig.Register(GlobalConfiguration.Configuration, out _container);
        }
    }
}
