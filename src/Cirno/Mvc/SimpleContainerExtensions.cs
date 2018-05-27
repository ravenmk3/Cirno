using System;
using Cirno.Ioc.Simple;
using Cirno.Mvc.Discovery;
using Cirno.Routing;

namespace Cirno.Mvc
{
    public static class SimpleContainerExtensions
    {
        public static ISimpleContainer AddMvc(this ISimpleContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            container.RegisterSingleton<IActionDiscovery, AppDomainActionDiscovery>();
            container.RegisterSingleton<IRouter, MvcSimpleRouter>();
            return container;
        }
    }
}