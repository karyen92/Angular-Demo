using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Demo.Core.Database;

namespace AugularJsFrameworkDemo.Configs.Windsor.Installers
{
    public class DbContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDomainModelContainer>()
                .ImplementedBy<DomainModelContainer>().LifestylePerWebRequest());
        }
    }
}
