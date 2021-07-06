using System.Collections.Generic;

namespace JasonStorey
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Returns a random element from the collection 
        /// </summary>
        public static T GetRandom<T>(this IList<T> items) => items[UnityEngine.Random.Range(0, items.Count)];
    }
}