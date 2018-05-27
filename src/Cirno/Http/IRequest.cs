using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace Cirno.Http
{
    public interface IRequest : IDisposable
    {
        HttpMethod Method { get; }

        Uri Url { get; }

        string Path { get; }

        NameValueCollection Query { get; }

        IReadOnlyDictionary<string, string> Headers { get; }

        IReadOnlyDictionary<string, string> Cookies { get; }

        Stream Body { get; }
    }
}