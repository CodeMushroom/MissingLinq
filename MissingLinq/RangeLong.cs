using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides a range of longs.
    /// </summary>
    public class RangeLong : IRange<long>
    {
        /// <summary>
        /// Constructs a new range with the provided start and end points.
        /// </summary>
        /// <param name="start">The starting point of the range.</param>
        /// <param name="end">The ending point of the range.</param>
        public RangeLong(long start, long end)
        {
            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Gets the enumerator for the current range.
        /// </summary>
        /// <returns>Returns the enumerator for the current range.</returns>
        public IEnumerator<long> GetEnumerator()
        {
            if (Start < End)
            {
                for (long i = Start; i <= End; i++)
                {
                    yield return i;
                }
            }
            else
            {
                for (long i = Start; i >= End; i--)
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Gets the enumerator for the current range.
        /// </summary>
        /// <returns>Returns the enumerator for the current range.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Gets or sets the starting point.
        /// </summary>
        public long Start { get; set; }

        /// <summary>
        /// Gets or sets the ending point.
        /// </summary>
        public long End { get; set; }
    }
}
