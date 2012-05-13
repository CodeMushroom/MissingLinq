using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingLinq
{
    /// <summary>
    /// Provides a set of extension methods for IEnumerable sets.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Appends an item to a given set.
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="enumerable">The set to be appended to.</param>
        /// <param name="newItem">The new item to append.</param>
        /// <returns>Returns the set with the appended item.</returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T newItem)
        {
            if (enumerable == null) yield return newItem;
            foreach (T item in enumerable) yield return item;
            yield return newItem;
        }

        /// <summary>
        /// Appends an set to a given set.
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="enumerable">The set to be appended to.</param>
        /// <param name="newItemSet">The new item set to append.</param>
        /// <returns>Returns the set with the appended item.</returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, IEnumerable<T> newItemSet)
        {
            if (enumerable == null && newItemSet == null) throw new InvalidOperationException("Cannot append nothing to nothing.");
            if (enumerable != null)
            {
                foreach (T item in enumerable) yield return item;
            }
            if (newItemSet != null)
            {
                foreach (T newItem in newItemSet) yield return newItem;
            }
        }

        /// <summary>
        /// Returns the set of elements that are distinct based upon proximity.  Given a set { A, B, A, A, B, B, A }
        /// the returned result would be { A, B, A, B, A }.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="enumerable">The set of elements to determine distinct based on proximity.</param>
        /// <returns>Returns the set of elements who are distinct based on proximity.</returns>
        public static IEnumerable<T> DistinctUntilChanged<T>(this IEnumerable<T> enumerable)
            where T : IEquatable<T>
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            using (var enumerator = enumerable.GetEnumerator())
            {
                if (!enumerator.MoveNext()) yield break;

                T lastItem = enumerator.Current;
                yield return lastItem;
                while (enumerator.MoveNext())
                {
                    T currentItem = enumerator.Current;
                    if (ReferenceEquals(lastItem, null) && ReferenceEquals(currentItem, null)) continue;
                    else if (!ReferenceEquals(lastItem, null) && lastItem.Equals(enumerator.Current)) continue;

                    lastItem = currentItem;
                    yield return currentItem;
                }

            }
        }

        /// <summary>
        /// Iterates though an IEnumerable and executes a given action on that enumerable.
        /// </summary>
        /// <typeparam name="T">The generic type of the enumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to iterate through and execute an action against.</param>
        /// <param name="action">This is the action to be executed.  This can be null.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null || action == null) return;
            foreach (T item in enumerable) action(item);
        }

        /// <summary>
        /// Iterates though an IEnumerable and executes a given action on that enumerable.
        /// </summary>
        /// <typeparam name="T">The generic type of the enumerable.</typeparam>
        /// <param name="enumerable">The IEnumerable to iterate through and execute an action against.</param>
        /// <param name="action">This is the action to be executed.  This can be null.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            if (enumerable == null || action == null) return;
            int i = 0;
            foreach (T item in enumerable) action(item, i++);
        }

        /// <summary>
        /// Determines if two sets are the same.  The sets must also be in the same order.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="enumerable">The current set to compare.</param>
        /// <param name="other">The other set to compare against.</param>
        /// <returns>Returns true if the two sets are in the same order and contain the same elements.</returns>
        public static bool Matches<T>(this IEnumerable<T> enumerable, IEnumerable<T> other)
            where T : IEquatable<T>
        {
            if (enumerable == null && other == null) return true;
            if ((enumerable == null && other != null) || (enumerable != null && other == null)) return false;
            if (ReferenceEquals(enumerable, other)) return true;

            var currentEnumerator = enumerable.GetEnumerator();
            var otherEnumerator = other.GetEnumerator();

            while (currentEnumerator.MoveNext() && otherEnumerator.MoveNext())
            {
                if (ReferenceEquals(currentEnumerator.Current, otherEnumerator.Current)) continue;
                if (ReferenceEquals(currentEnumerator.Current, null) || ReferenceEquals(otherEnumerator.Current, null)) return false;
                if (currentEnumerator.Current.Equals(otherEnumerator.Current) == false) return false;
            }
            return true;
        }
    }
}
