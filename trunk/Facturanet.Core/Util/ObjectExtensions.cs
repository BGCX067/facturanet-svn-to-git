using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Util
{
    public static class ObjectExtensions
    {
        public static void DoIfItIs<T>(this object item, Action<T> action)
            where T : class
        {
            var casted = item as T;
            if (casted != null)
                action(casted);
        }
    }
}
