using System;
using Cirno.Mvc.Discovery;
using Cirno.Mvc.Invocation;
using Cirno.Routing.Simple;

namespace Cirno.Mvc
{
    public class MvcSimpleRouter : SimpleRouter
    {
        public MvcSimpleRouter(IServiceProvider provider, IActionDiscovery discovery)
        {
            this.Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            this.Discovery = discovery ?? throw new ArgumentNullException(nameof(discovery));
            this.MapRoutes();
        }

        protected IServiceProvider Provider { get; }

        protected IActionDiscovery Discovery { get; }

        private void MapRoutes()
        {
            var actions = this.Discovery.Discover();
            foreach (var item in actions)
            {
                var handler = new InvokeActionHandler(this.Provider, item.ControllerType, item.ActionMethod);
                base.Map(item.UriTemplate, item.Method, handler);
            }
        }
    }
}