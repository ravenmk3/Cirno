using System;
using System.Collections.Generic;
using Cirno.Common;
using Cirno.Http.Cookies;

namespace Cirno.Http
{
    public class Response : IResponse
    {
        public Response()
        {
            this.Status = 200;
            this.Headers = new Dictionary<string, string>();
            this.Cookies = new List<Cookie>();
        }

        public int Status { get; set; }

        public IDictionary<string, string> Headers { get; }

        public ICollection<Cookie> Cookies { get; }

        public ILazyContent Body { get; set; }

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