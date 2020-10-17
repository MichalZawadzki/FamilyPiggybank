using System;
using System.Runtime.Serialization;

namespace FamilyPiggybank.API.Infrastructure
{
    public static class EnumExtensions
    {
        public static string ToSerializationName(this Enum value)
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            return fieldInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false) is EnumMemberAttribute[] attribs &&
                   attribs.Length > 0
                ? attribs[0].Value
                : null;
        }

        public static T? FromSerializationName<T>(this string attributeName) where T : struct
        {
            var values = Enum.GetValues(typeof(T));

            foreach (Enum enumValue in values)
            {
                if (enumValue.ToSerializationName() == attributeName)
                    return (T)Enum.Parse(typeof(T), enumValue.ToString());
            }

            return null;
        }
    }
}
