using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Represents a range of numbers.
    /// </summary>
    public interface IRange<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gets or sets the starting point.
        /// </summary>
        T Start { get; set; }

        /// <summary>
        /// Gets or sets the ending point.
        /// </summary>
        T End { get; set; }
    }
}
