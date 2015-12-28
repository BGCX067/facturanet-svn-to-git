using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Util
{
    public static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type type, Type theInterface)
        {
            return (type.GetInterfaces().Contains(theInterface));
        }

        public static bool InheritsClass(this Type type, Type theClass)
        {
            if (type == null)
                return false;
            if (type == theClass)
                return true;
            else
                return type.BaseType.InheritsClass(theClass);
        }

        public static bool ImplementsInterface<InterfaceType>(this Type type)
        {
            return ImplementsInterface(type, typeof(InterfaceType));
        }
    }
}
