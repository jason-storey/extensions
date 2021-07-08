using System;
using System.Collections.Generic;
using System.Linq;

namespace JasonStorey
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Returns a random element from the collection 
        /// </summary>
        public static T GetRandom<T>(this IList<T> items) => items[UnityEngine.Random.Range(0, items.Count)];
        
        /// <summary>
        ///     Returns highest element in collection by provided comparitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="score">The score</param>
        /// <returns>T</returns>
        public static T MaxBy<T>(this IEnumerable<T> source, Func<T, IComparable> score) => 
            source.Aggregate((x, y) => score(x).CompareTo(score(y)) > 0 ? x : y);

        /// <summary>
        ///     Returns lowest element in collection by provided comparitor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="score">The score</param>
        /// <returns>T.</returns>
        public static T MinBy<T>(this IEnumerable<T> source, Func<T, IComparable> score) => 
            source.Aggregate((x, y) => score(x).CompareTo(score(y)) < 0 ? x : y);

        public static string ToDisplayString<T>(this IEnumerable<T> source)
        {
            if (source == null) return "null";
            var s = "[";
            s = source.Aggregate(s, (res, x) => res + x + ", ");
            return $"{s.Substring(0, s.Length - 2)}]";
        }

        /// <summary>
        ///     Joins all the elements of the list into a string separated by the given separator string.
        /// </summary>
        /// <typeparam name="T">List Type.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="separator">String separator.</param>
        /// <returns></returns>
        public static string ToDisplayString<T>(this IList<T> list, string separator)
        {
            if (list == null) return string.Empty;
            var builder = new System.Text.StringBuilder();
            for (var i = 0; i < list.Count - 1; i++)
            {
                builder.Append(list[i]);
                builder.Append(separator);
            }

            builder.Append(list[list.Count - 1]);
            return builder.ToString();
        }
        
    }
}