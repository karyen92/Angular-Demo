using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AugularJsFrameworkDemo.Startup))]
namespace AugularJsFrameworkDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
