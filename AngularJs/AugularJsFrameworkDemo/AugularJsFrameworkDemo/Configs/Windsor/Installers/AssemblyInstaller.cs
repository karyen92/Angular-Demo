using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AugularJsFrameworkDemo.Configs.Windsor.Installers
{
    public class AssemblyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var assemblies = new List<Assembly>
            {
                Assembly.GetExecutingAssembly()
            };

            var relatedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(x => x.Name.StartsWith("Demo."));
            assemblies.AddRange(relatedAssemblies.Select(Assembly.Load));
        }
    }
}