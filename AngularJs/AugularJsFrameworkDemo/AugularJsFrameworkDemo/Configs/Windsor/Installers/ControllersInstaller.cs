using System.Web.Http;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AugularJsFrameworkDemo.Configs.Windsor.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());

            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleScoped());

            container.Register(Component.For<System.Web.Http.Filters.IFilterProvider>()
                                   .ImplementedBy<WindsorFilterProvider>());
        }
    }
}
