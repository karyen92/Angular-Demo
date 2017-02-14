using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MongoDB.Driver;

namespace Demo.Core.Config.WIndsor.Installers
{
    public class MongoDatabaseInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.AppSettings["MongoConnection"];
            var mongoDb = new DataStore(connectionString);

            container.Register(
                Component.For<IMongoDatabase>().UsingFactoryMethod(() => mongoDb.DataBase).LifeStyle.Singleton
            );
        }
    }
}