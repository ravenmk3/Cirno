using System;
using System.Collections.Generic;
using Cirno.Http;

namespace Cirno.Routing.Simple
{
    public class SimpleRouter : IRouter
    {
        private readonly IDictionary<string, Node> table = new Dictionary<string, Node>();

        public void Map(string path, HttpMethod method, IHttpHandler handler)
        {
            if (!this.table.TryGetValue(path, out var node))
            {
                node = new Node();
                this.table[path] = node;
            }
            node.Set(method, handler);
        }

        public RouteResult Route(string path, HttpMethod method)
        {
            var result = new RouteResult();
            if (this.table.TryGetValue(path, out var node))
            {
                result.Handler = node.Get(method);
            }
            return result;
        }

        private class Node
        {
            private readonly IHttpHandler[] handlers = new IHttpHandler[7];

            public IHttpHandler Get(HttpMethod method)
            {
                var index = (int)method;
                if (index < 0 || index > 1)
                {
                    return null;
                }
                return this.handlers[index];
            }

            public void Set(HttpMethod method, IHttpHandler handler)
            {
                var index = (int)method;
                if (index < 0 || index > 1)
                {
                    return;
                }
                this.handlers[index] = handler;
            }
        }
    }
}