using System;

namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <summary>
    ///     Class to extend the functionality of the String class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Returns a new string in which a specified number of characters in the current instance beginning at from right have
        ///     been deleted.
        /// </summary>
        /// <param name="value">The string to modify to this instance. </param>
        /// <param name="count">The number of characters to delete. </param>
        /// <returns></returns>
        public static string RemoveRight(this string value, int count)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            return value.Length > count ? value.Remove(value.Length - count, count) : value;
        }

        /// <summary>
        ///     Returns a new string in which a specified number of characters in the current instance beginning at from left have
        ///     been deleted.
        /// </summary>
        /// <param name="value">The string to modify to this instance. </param>
        /// <param name="count">The number of characters to delete. </param>
        /// <returns></returns>
        public static string RemoveLeft(this string value, int count)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            return value.Length > count ? value.Remove(0, count) : value;
        }
    }
}