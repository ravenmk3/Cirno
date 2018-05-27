using System;
using System.Collections.Generic;
using Cirno.Http;

namespace Cirno.Routing
{
    public static class HttpContextExtensions
    {
        private const string RouteDataKey = "Routing.RouteData";

        public static IDictionary<string, string> GetRouteData(this IHttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Items.TryGetValue(RouteDataKey, out var value) && value is IDictionary<string, string> data)
            {
                return data;
            }
            return new Dictionary<string, string>();
        }

        public static void SetRouteData(this IHttpContext context, IDictionary<string, string> data)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Items[RouteDataKey] = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}