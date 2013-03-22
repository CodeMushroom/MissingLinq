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
