using System.Collections.Generic;
using Sting.Collection;

namespace Sting
{
    public static class CollectionExtensions
    {
        public static ReferenceArray<T> AsRef<T>(this T[] array) => new ReferenceArray<T>(array);

        public static ReferenceCollection<T> ToReferenceList<T>(this IEnumerable<T> items) where T : struct => new ReferenceCollection<T>(items);
    }
}