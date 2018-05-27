using System;
using System.Collections.Generic;
using System.Linq;

namespace Cirno.Ioc
{
    public static class ContainerExtensions
    {
        public static T Resolve<T>(this IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            return (T)container.Resolve(typeof(T));
        }

        public static T Resolve<T>(this IContainer container, string name)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return (T)container.Resolve(typeof(T), name);
        }

        public static IEnumerable<T> ResolveAll<T>(this IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            return container.ResolveAll(typeof(T)).Cast<T>();
        }
    }
}