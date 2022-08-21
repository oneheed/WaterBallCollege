using System.ComponentModel.DataAnnotations;

namespace Big2
{
    public static class ExtensionMethod
    {
        public static string GetDisplay(this Enum enumValue)
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
