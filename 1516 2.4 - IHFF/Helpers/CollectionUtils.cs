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
    }
}