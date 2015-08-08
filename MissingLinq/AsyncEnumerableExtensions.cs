using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides a set of extension methods for Task&lt;IEnumerable&gt; sets.
    /// </summary>
    public static class AsyncEnumerableExtensions
    {
        /// <summary>
        /// Iterates though an IEnumerable and executes a given action on that enumerable once the task has completed.
        /// </summary>
        /// <typeparam name="T">The generic type of the enumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable task to iterate through and execute an action against.</param>
        /// <param name="action">This is the action to be executed.  This can be null.</param>
        public static async Task ForEachAsync<T>(this Task<IEnumerable<T>> enumerable, Action<T> action)
        {
            (await enumerable).ForEach(action);
        }
    }
}
