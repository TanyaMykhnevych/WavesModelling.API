using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Waves.Services.Extensions.Enums
{
    public static class EnumsExtensions
    {
        public static String GetDescription(Enum value)
        {
            return value.GetType()
                        .GetMember(value.ToString())
                        .FirstOrDefault()
                        ?.GetCustomAttribute<DescriptionAttribute>()
                        ?.Description;
        }
    }
}
