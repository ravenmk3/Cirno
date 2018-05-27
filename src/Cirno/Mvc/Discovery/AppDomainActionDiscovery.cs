using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cirno.Routing.Attributes;

namespace Cirno.Mvc.Discovery
{
    public class AppDomainActionDiscovery : IActionDiscovery
    {
        public IEnumerable<ActionDescription> Discover()
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(t => !t.IsAbstract && typeof(Controller).IsAssignableFrom(t))
                .ToArray();

            var result = new List<ActionDescription>();

            foreach (var type in types)
            {
                var route = type.GetCustomAttribute<RouteAttribute>();
                if (route == null)
                {
                    continue;
                }
                var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                foreach (var method in methods)
                {
                    var actions = this.ProcessMethod(type, method, route);
                    if (actions != null && actions.Count > 0)
                    {
                        result.AddRange(actions);
                    }
                }
            }

            return result.ToArray();
        }

        private IList<ActionDescription> ProcessMethod(Type type, MethodInfo method, RouteAttribute route)
        {
            var result = new List<ActionDescription>();

            var attrs = method.GetCustomAttributes();
            if (attrs != null)
            {
                foreach (var attr in attrs)
                {
                    if (attr is ActionAttribute actionAttribute)
                    {
                        var action = new ActionDescription()
                        {
                            ControllerType = type,
                            ActionMethod = method,
                            Method = actionAttribute.Method,
                            Order = actionAttribute.Order,
                            UriTemplate = String.Format("{0}/{1}",
                                (route.Template ?? String.Empty).Replace('\\', '/').Trim('/'),
                                (actionAttribute.Template ?? String.Empty).Replace('\\', '/').Trim('/')),
                        };
                        result.Add(action);
                        // TODO 组合并规范化路径
                    }
                }
            }

            return result;
        }
    }
}