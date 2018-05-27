using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace Cirno.Http
{
    public class Request : IRequest
    {
        public Request(HttpMethod method, Uri url, Stream body)
        {
            this.Method = method;
            this.Url = url ?? throw new ArgumentNullException(nameof(url));
            this.Body = body ?? throw new ArgumentNullException(nameof(body));
            this.Path = url.LocalPath;
            this.Query = new NameValueCollection();
            this.Headers = new Dictionary<string, string>();
            this.Cookies = new Dictionary<string, string>();
        }

        public HttpMethod Method { get; }

        public Uri Url { get; }

        public string Path { get; }

        public NameValueCollection Query { get; }

        public IReadOnlyDictionary<string, string> Headers { get; }

        public IReadOnlyDictionary<string, string> Cookies { get; }

        public Stream Body { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.Body is IDisposable disposable)
            {
                disposable.Dispose();
            }
            this.Body = null;
        }
    }
}