using System.ComponentModel;
using System.Reflection;

namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Extension
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : nameof(enumValue);
        }
    }
}
