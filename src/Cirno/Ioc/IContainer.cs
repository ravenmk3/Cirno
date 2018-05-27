using System;
using System.Collections.Generic;

namespace Cirno.Ioc
{
    public interface IContainer : IServiceProvider
    {
        Object Resolve(Type type);

        Object Resolve(Type type, String name);

        IEnumerable<Object> ResolveAll(Type type);
    }
}