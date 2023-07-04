using C3M1H1_YouTube.Models;

namespace C3M1H1_YouTube.Conditions
{
    internal static class Condition
    {
        public static bool GreaterThanEqualCondition(Video video, TimeSpan length)
        {
            return video.Length >= length;
        }

        public static bool LessThanEqualCondition(Video video, TimeSpan length)
        {
            return video.Length <= length;
        }
    }
}
