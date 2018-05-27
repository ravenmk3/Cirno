using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Cirno.Http
{
    public class HttpContext : IHttpContext
    {
        public HttpContext(IRequest request)
        {
            this.Request = request ?? throw new ArgumentNullException(nameof(request));
            this.Items = new Dictionary<string, object>();
        }

        public IRequest Request { get; }

        public IResponse Response { get; set; }

        public IDictionary<string, object> Items { get; }

        public IPrincipal User { get; set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.Request is IDisposable request)
            {
                request.Dispose();
            }
            if (this.Response is IDisposable response)
            {
                response.Dispose();
            }
            foreach (var item in this.Items.Values)
            {
                if (item is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            this.Items.Clear();
        }
    }
}