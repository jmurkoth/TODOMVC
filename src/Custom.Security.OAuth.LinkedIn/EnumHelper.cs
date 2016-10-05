using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Custom.Security.OAuth.LinkedIn
{
    public static class EnumHelper
    {
        public static string GetDescription( this Enum enm)
        {
            string description = string.Empty;
            var type = enm.GetType();
            var memberInfo = type.GetMember(enm.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
                description = attrs?.Description;
            }
            return description;
        }
    }
}
