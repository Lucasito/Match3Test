using System;
using System.ComponentModel;

namespace Match3Test.Helpers
{
    public static class ReflectionHelper
    {
        public static string GetCallerMemberName([System.Runtime.CompilerServices.CallerMemberName] string callerMemberName = "")
        {
            return callerMemberName;
        }

        public static string GetCustomDescription(object objectEnum)
        {
            var fieldInfo = objectEnum.GetType().GetField(objectEnum.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Description : objectEnum.ToString();
        }

        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }
    }
}
