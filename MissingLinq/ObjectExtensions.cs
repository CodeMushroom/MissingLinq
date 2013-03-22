using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides a set of extension methods for all objects.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns a default value if the input is null.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="input">The input to be checked.</param>
        /// <param name="defaultValue">The default value to be used if the input is null.</param>
        /// <returns>Returns the default value if the input is null.</returns>
        public static T Default<T>(this T input, T defaultValue)
        {
            return input == null ? defaultValue : input;
        }
    }
}
