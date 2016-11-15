using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AugularJsFrameworkDemo.Configs.Windsor.Installers
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IActionInvoker>()
                    .ImplementedBy<WindsorActionInvoker>()
                    .LifestyleTransient()
                    .DependsOn(new { container = container }));
        }
    }
}
