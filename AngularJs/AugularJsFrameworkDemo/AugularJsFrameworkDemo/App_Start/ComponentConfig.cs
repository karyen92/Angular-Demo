using Castle.Windsor;
using Demo.Core.Config.Windsor;
using FluentValidation.Mvc;

namespace AugularJsFrameworkDemo
{
    public class ComponentConfig
    {
        public static void Register(IWindsorContainer container)
        {
            FluentValidationModelValidatorProvider.Configure(provider => provider.ValidatorFactory = new WindsorValidatorFactory(container));
        }
    }
}