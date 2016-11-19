using System;
using System.Collections.Generic;

namespace Day15.ConsoleApplication
{
    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source) action(item);
        }
    }
}