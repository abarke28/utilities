using System;
using System.Collections.Generic;
using System.Text;

namespace utilities
{
    public static class ObjectEnumerable
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
    }
}
