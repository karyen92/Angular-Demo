using System.Globalization;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AugularJsFrameworkDemo.Helpers
{
    public static class JsonHelper
    {
        public static IHtmlString ToJson(this HtmlHelper htmlHelper, object obj)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            jsonSettings.Converters.Add(new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AdjustToUniversal });

            var json = JsonConvert.SerializeObject(obj, jsonSettings);
            return MvcHtmlString.Create(json);
        }
    }
}
