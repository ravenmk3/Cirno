using System;
using System.Collections.Generic;

namespace Cirno.Ioc
{
    public class ActivatorContainer : IContainer
    {
        public object GetService(Type serviceType)
        {
            return Activator.CreateInstance(serviceType);
        }

        public object Resolve(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public object Resolve(Type type, string name)
        {
            return Activator.CreateInstance(type);
        }

        public IEnumerable<object> ResolveAll(Type type)
        {
            var instance = Activator.CreateInstance(type);
            return new object[] { instance };
        }
    }
}