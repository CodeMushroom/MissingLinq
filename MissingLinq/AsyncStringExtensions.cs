using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides a set of extension methods for operations against Task&lt;string&gt;
    /// </summary>
    public static class AsyncStringExtensions
    {
        /// <summary>
        /// Determines whether or not the current string contains the specified value.
        /// </summary>
        /// <param name="input">The string to be checked once the task has finished.</param>
        /// <param name="value">The value to check the string for.</param>
        /// <returns>Returns true if the current string contains the provided value.</returns>
        public static async Task<bool> ContainsAsync(this Task<string> task, string value)
        {
            return (await task).Contains(value);
        }

        /// <summary>
        /// Determines whether or not the current string contains the specified value.
        /// </summary>
        /// <param name="input">The string to be checked once the task has finished.</param>
        /// <param name="value">The value to check the string for.</param>
        /// <param name="comparisonType">The string comparison type to be used for this contains operation.</param>
        /// <returns>Returns true if the current string contains the provided value.</returns>
        public static async Task<bool> ContainsAsync(this Task<string> task, string value, StringComparison compareType)
        {
            return (await task).Contains(value, compareType);
        }
    }
}
