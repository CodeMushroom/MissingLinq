using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides a set of extensions for numbers.
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Creates a range from start to end.
        /// </summary>
        /// <param name="start">The starting point of the range.</param>
        /// <param name="end">The end point of the range.</param>
        /// <returns>Returns the range of numbers from start to end.</returns>
        public static IRange<long> To(this long start, long end)
        {
            return new RangeLong(start, end);
        }

        /// <summary>
        /// Creates a range from start to end.
        /// </summary>
        /// <param name="start">The starting point of the range.</param>
        /// <param name="end">The end point of the range.</param>
        /// <returns>Returns the range of numbers from start to end.</returns>
        public static IRange<long> To(this int start, int end)
        {
            return new RangeLong(start, end);
        }
    }
}
