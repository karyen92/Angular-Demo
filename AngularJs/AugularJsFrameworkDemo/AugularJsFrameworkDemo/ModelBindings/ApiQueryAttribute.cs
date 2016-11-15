using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace AugularJsFrameworkDemo.ModelBindings
{
    public class ApiQueryAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new ApiQueryBinding(parameter);
        }
    }

    public class ApiQueryBinding : HttpParameterBinding
    {
        private readonly string _parameterName;
        private readonly Type _parameterType;

        public ApiQueryBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
            _parameterName = descriptor.ParameterName;
            _parameterType = descriptor.ParameterType;
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var rawQuery = string.Empty;
            var queryStrings = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

            foreach (var par in queryStrings.AllKeys.Where(par => par == _parameterName))
            {
                rawQuery = queryStrings[par];
                break;
            }

            if (string.IsNullOrEmpty(rawQuery))
            {
                actionContext.ActionArguments.Add(_parameterName, Activator.CreateInstance(_parameterType));
                return Task.FromResult(0);
            }

            var apiString = new ApiQueryString(rawQuery);

            actionContext.ActionArguments.Add(_parameterName, apiString.BindModel(_parameterType));

            return Task.FromResult(0);
        }
    }
}