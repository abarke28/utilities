using System;
using System.Collections.Generic;
using System.Text;

namespace utilities
{
    public static class EnumerableUtils
    {
        /// <summary>
        /// Returns an IEnumerable of new, distinct objects of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">Number of Objects to create</param>
        public static IEnumerable<T> Repeat<T>(int count) where T : new()
        {
            for (int i=0; i<count; i++)
            {
                yield return new T();
            }
        }

        /// <summary>
        /// Returns new array with element removed from specified index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Source Array</param>
        /// <param name="index">Index to be removed</param>
        public static T[] ArrayRemoveAt<T> (T[] source, int index)
        {
            if (index >= source.Length || index < 0) throw new ArgumentException(nameof(index));
            if (source == null) throw new ArgumentException(nameof(source));
            if (source.Length == 1) return null;

            var result = new T[source.Length - 1];
            var j = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (i != index)
                {
                    result[j++] = source[i];
                }
            }

            return result;
        }
    }
}
