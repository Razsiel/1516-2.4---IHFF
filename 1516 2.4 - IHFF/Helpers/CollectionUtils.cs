using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Helpers
{
    public static class CollectionUtils
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <param name="allowDuplicates"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetRandomElements<T>(IEnumerable<T> source, int count, bool allowDuplicates = false)
        {
            // Create a random generator object
            Random random = new Random();
            // Creates a temporary collection
            List<T> collection = new List<T>();
            while (collection.Count() < count)
            {
                // Get a random element from the source collection
                T randomElemen = source.ElementAt(random.Next(0, source.Count() - 1));
                // Check whether the ranom element doesn't already exist in the temporary collection, 
                // othwerwise keep getting a random element untill it is different
                while (collection.Exists(x => x.Equals(randomElemen)))
                {
                    randomElemen = source.ElementAt(random.Next(0, source.Count() - 1));
                }
                // Add the random element to the temporary collection
                collection.Add(randomElemen);
            }

            return collection;
        }
    }
}