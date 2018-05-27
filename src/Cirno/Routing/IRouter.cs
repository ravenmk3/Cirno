using System;
using Cirno.Http;

namespace Cirno.Routing
{
    public interface IRouter
    {
        RouteResult Route(string path, HttpMethod method);
    }
}