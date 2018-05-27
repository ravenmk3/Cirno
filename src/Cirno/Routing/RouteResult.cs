using System;
using System.Collections.Generic;
using Cirno.Http;

namespace Cirno.Routing
{
    public sealed class RouteResult
    {
        public RouteResult()
        {
            this.RouteData = new Dictionary<string, string>();
        }

        public IDictionary<string, string> RouteData { get; }

        public IHttpHandler Handler { get; set; }
    }
}