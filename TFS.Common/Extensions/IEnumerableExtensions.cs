using System;
using System.Collections.Generic;

namespace TFS.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<TObject>(this IEnumerable<TObject> items, Action<TObject> action)
        {
            foreach (var item in items)
                action.Invoke(item);
        }

    }
}
