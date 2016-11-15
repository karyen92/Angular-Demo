using System;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

namespace AugularJsFrameworkDemo.ModelBindings
{
    public class ApiQueryString : NameValueCollection
    {
        private const char EntrySeparator = ';';
        private const char KeyValueSeparator = ':';

        public ApiQueryString(string rawQuery)
        {
            ParseRawQuery(rawQuery);
        }

        private void ParseRawQuery(string rawQuery)
        {
            foreach (var keyValue in rawQuery.Split(new[] { EntrySeparator }, StringSplitOptions.RemoveEmptyEntries).Select(entry => entry.Split(KeyValueSeparator)))
            {
                if (keyValue.Length != 2)
                    throw new ArgumentException("Expected 2 elements composing the key/value pair for an entry in the query string.");
                var key = keyValue[0].ToLower();
                var value = keyValue[1];
                Add(key, value);
            }
        }

        public object BindModel(Type type)
        {
            var dto = Activator.CreateInstance(type);

            var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in propertyInfos)
            {
                var propertyName = propertyInfo.Name;
                var parsedValue = this[propertyName.ToLower()];
                if (parsedValue == null)
                    continue;
                var propertyType = propertyInfo.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                    propertyInfo.SetValue(dto, new Guid(parsedValue), null);
                else if (propertyType == typeof(string))
                    propertyInfo.SetValue(dto, parsedValue, null);
                else if (propertyType == typeof(int))
                    propertyInfo.SetValue(dto, int.Parse(parsedValue), null);
                else if (propertyType == typeof(DateTime))
                    propertyInfo.SetValue(dto, DateTime.Parse(parsedValue), null);
                else if (propertyType == typeof(System.ComponentModel.ListSortDirection))
                {
                    System.ComponentModel.ListSortDirection parseEnum;
                    Enum.TryParse(parsedValue, true, out parseEnum);
                    propertyInfo.SetValue(dto, parseEnum);
                }

                else
                    throw new NotImplementedException(string.Format("Unable to parse value for type: {0}", propertyType));
            }

            return dto;
        }
    }
}