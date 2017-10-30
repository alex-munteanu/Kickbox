using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Kickbox.Helpers
{
    internal static class UrlHelpers
    {
        public static string ToQueryString(this object request, string separator = ",")
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var properties = request.GetType().GetTypeInfo().DeclaredProperties.Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x =>
                {
                    var customAttribute = x.GetCustomAttribute<JsonPropertyAttribute>();
                    return customAttribute != null ? customAttribute.PropertyName : x.Name;
                }, x => x.GetValue(request, null));

            var propertyNames = properties.Where(x => !(x.Value is string) && x.Value is IEnumerable).Select(x => x.Key)
                .ToList();

            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType().GetTypeInfo();

                var valueElemType = valueType.IsGenericType
                    ? valueType.GenericTypeArguments[0].GetTypeInfo()
                    : valueType.GetElementType().GetTypeInfo();

                if (valueElemType.IsPrimitive || valueElemType.BaseType == typeof(string))
                {
                    var enumerable = (IEnumerable) properties[key];
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            return string.Join("&",
                properties.Select(x =>
                    string.Concat(Uri.EscapeDataString(x.Key), "=", x.Value.ToString())));
        }
    }
}
