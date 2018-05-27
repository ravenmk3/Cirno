using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Cirno.Http
{
    public interface IHttpContext : IDisposable
    {
        IRequest Request { get; }

        IResponse Response { get; set; }

        IDictionary<string, object> Items { get; }

        IPrincipal User { get; set; }
    }
}