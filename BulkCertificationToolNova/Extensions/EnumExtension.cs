using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BulkCertificationToolNova.Extensions
{
    internal static class EnumExtension
    {
        public static T GetCustomAttribyte<T>(this Enum item) where T: Attribute
        {
            T result = null;

            Type type = item.GetType();
            MemberInfo[] memberInfo = type.GetMember(item.ToString());

            if (memberInfo.Length > 0)
            {
                Object[] attrs = memberInfo[0].GetCustomAttributes(typeof(T), false);
                if (attrs.Length > 0)
                {
                    result = (T)attrs[0];
                }
            }

            return result;
        }

        public static IEnumerable<T> GetItems<T>() where T : struct
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
