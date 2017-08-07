namespace SkypeForBusinessAvailabilityHandler.Core
{
    public static class StringExtensions
    {
        public static string RemoveRight(this string value, int length)
        {
            return value.Length > length ? value.Remove(value.Length - length, length) : value;
        }

        public static string RemoveLeft(this string value, int length)
        {
            return value.Length > length ? value.Remove(0, length) : value;
        }
    }
}