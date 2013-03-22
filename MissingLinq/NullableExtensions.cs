using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides some extension methods for nullable types.
    /// </summary>
    public static class NullableExtensions
    {
        /// <summary>
        /// Returns a default value if the input is null.
        /// </summary>
        /// <typeparam name="T">The nullable type.</typeparam>
        /// <param name="input">The input to be checked.</param>
        /// <param name="defaultValue">The default value to be used if the input is null.</param>
        /// <returns>Returns the default value if the input is null.</returns>
        public static T Default<T>(this T? input, T defaultValue) where T : struct
        {
            return input.HasValue ? input.Value : defaultValue;
        }
    }
}
