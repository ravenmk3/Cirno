using System;
using System.Collections.Generic;
using Cirno.Common;
using Cirno.Http.Cookies;

namespace Cirno.Http
{
    public interface IResponse : IDisposable
    {
        int Status { get; set; }

        IDictionary<string, string> Headers { get; }

        ICollection<Cookie> Cookies { get; }

        ILazyContent Body { get; set; }
    }
}