using Castle.Windsor;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AugularJsFrameworkDemo.Startup))]
namespace AugularJsFrameworkDemo
{
    public partial class Startup
    {
        private static IWindsorContainer _container;

        public static void SetContainer(IWindsorContainer container)
        {
            _container = container;
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
