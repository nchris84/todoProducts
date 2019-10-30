using System;
using System.Linq;
using System.Reflection;

namespace todoProducts.Extension
{
    public static class Extensions
    {
        public static string MethodInfo(this string s, MethodBase mb)
        {
            return $"{s}.{string.Join(",", mb.GetParameters().Select(o => string.Format("{0} {1}", o.ParameterType, o.Name)).ToArray())}";
        }

        public static bool IsGuid(string strGuid)
        {
            Guid x;
            return Guid.TryParse(strGuid, out x);
        }
    }
}