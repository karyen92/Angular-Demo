using System;
using Demo.Framework.Attributes;

namespace Demo.Framework.Extensions
{
    public static class AttributeExtensions
    {
        public static string CollectionName(this Type type)
        {
            var ts = type
                .GetCustomAttributes(typeof(CollectionNameAttribute), false);
            
            return ts.Length > 0 ? ((CollectionNameAttribute)ts[0]).Name : null;
        }
    }
}
