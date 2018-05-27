using System;
using System.Linq;
using System.Reflection;

namespace Cirno.Ioc.Simple
{
    public static class ConstructorFinder
    {
        public static ConstructorInfo Find(Type type)
        {
            var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (ctors.Length > 0)
            {
                if (ctors.Length > 1)
                {
                    var ctor = FindInjectionConstructor(ctors);
                    if (ctor != null) { return ctor; }
                    return ctors.OrderBy(c => c.GetParameters().Length).FirstOrDefault();
                }
                return ctors[0];
            }
            return null;
        }

        public static ConstructorInfo FindInjectionConstructor(ConstructorInfo[] ctors)
        {
            return ctors.FirstOrDefault(ctor =>
            {
                var attribs = ctor.GetCustomAttributes(typeof(InjectAttribute), true);
                return (attribs != null && attribs.Length > 0);
            });
        }
    }
}