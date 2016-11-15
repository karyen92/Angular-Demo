using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using AugularJsFrameworkDemo.Configs.Windsor;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace AugularJsFrameworkDemo
{
    public class ContainerConfig
    {
        public static void Register(HttpConfiguration httpConfiguration, out  IWindsorContainer container)
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
        }
    }
}
