using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides a set of extension methods for the base string class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether or not the current string contains the specified value.
        /// </summary>
        /// <param name="input">The string to be checked.</param>
        /// <param name="value">The value to check the string for.</param>
        /// <param name="comparisonType">The string comparison type to be used for this contains operation.</param>
        /// <returns>Returns true if the current string contains the provided value.</returns>
        public static bool Contains(this string input, string value, StringComparison comparisonType)
        {
            return input.IndexOf(value, comparisonType) != -1;
        }

        /// <summary>
        /// Determines is a string is null or empty.
        /// </summary>
        /// <param name="input">The string to be checked.</param>
        /// <returns>Returns true if the string is either null or empty.</returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// Determines if a string is null, empty, or only white space.
        /// </summary>
        /// <param name="input">The string to be checked.</param>
        /// <returns>Returns true if the string is either null, empty, or only white space.</returns>
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
    }
}
