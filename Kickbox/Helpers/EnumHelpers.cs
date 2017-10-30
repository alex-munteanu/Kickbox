using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Kickbox.Helpers
{
    internal static class EnumHelpers
    {
        public static string ToEnumString<T>(this T enumInstance)
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("instance", "Must be enum type");
            }

            var enumString = enumInstance.ToString();
            var field = typeof(T).GetTypeInfo().GetDeclaredField(enumString);
            if (field != null) // instance can be a number that was cast to T, instead of a named value, or could be a combination of flags instead of a single value
            {
                var attr = (EnumMemberAttribute)field.GetCustomAttributes(typeof(EnumMemberAttribute), false).SingleOrDefault();
                if (attr != null) // if there's no EnumMember attr, use the default value
                {
                    enumString = attr.Value;
                }
            }
            return enumString;
        }
    }
}
