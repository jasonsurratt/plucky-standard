using System;
using System.Collections.Generic;
using System.Linq;

namespace Plucky.SystemExtensions
{
    public static class IEnumerableExtensions
    {
        public static Random rng = new Random();

        public static void ForEach<T>(this IEnumerable<T> coll, Action<T> action)
        {
            foreach (T element in coll)
            {
                action(element);
            }
        }

        public static T Smallest<T>(this IEnumerable<T> coll, Func<T, T, int> compareTo)
        {
            T result = default(T);
            bool foundOne = false;

            foreach (T t in coll)
            {
                if (!foundOne)
                {
                    result = t;
                    foundOne = true;
                }
                else
                {
                    if (compareTo(result, t) > 0)
                    {
                        result = t;
                    }
                }
            }

            return result;
        }

        public static T PickOne<T>(this IEnumerable<T> coll)
        {
            switch (coll)
            {
                case IList<T> list:
                    return list[rng.Next() % list.Count];
                default:
                    return coll.ElementAt(rng.Next() % coll.Count());
            }
        }
    }
}
