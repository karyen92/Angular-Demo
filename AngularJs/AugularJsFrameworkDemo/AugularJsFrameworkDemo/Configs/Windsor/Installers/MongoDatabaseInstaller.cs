using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MongoDB.Driver;


namespace AugularJsFrameworkDemo.Configs.Windsor.Installers
{
    public class MongoDatabaseInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assemblies = new List<Assembly>
            {
                 Assembly.GetExecutingAssembly()
            };

            var relatedAssemblies =
                Assembly.GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .Where(x => x.Name.StartsWith("WindsorApplication"));
            assemblies.AddRange(relatedAssemblies.Select(Assembly.Load));

            var mongoDb = new DataStore("server=mongodb://localhost:27017;database=test");

            container.Register(
                Component.For<IMongoDatabase>().UsingFactoryMethod(() => mongoDb.DataBase).LifeStyle.Singleton
            );
        }
    }
}