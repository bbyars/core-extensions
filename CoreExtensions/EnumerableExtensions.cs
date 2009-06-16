using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoreExtensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Map<T, TResult>(this IEnumerable<T> iterator, Func<T, TResult> mapper)
        {
            return new List<T>(iterator).Select(mapper).ToArray();
        }

        public static IEnumerable<TResult> Map<TResult>(this IEnumerable iterator, Func<object, TResult> mapper)
        {
            var genericList = new List<object>();
            foreach (var item in iterator)
            {
                genericList.Add(item);
            }
            return Map(genericList, mapper);
        }
    }
}