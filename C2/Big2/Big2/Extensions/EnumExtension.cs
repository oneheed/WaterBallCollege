using System.ComponentModel.DataAnnotations;

namespace Big2.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var name = enumValue.ToString();
            var field = enumValue.GetType().GetField(name);
            var displayName = name;

            if (field != null)
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                displayName = attribute?.Name ?? name;
            }

            return displayName;
        }
    }
}
