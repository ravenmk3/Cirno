using System;
using System.Threading.Tasks;

namespace Cirno.Http.Middleware
{
    public delegate Task NextDelegate(IHttpContext context, IMiddlewareDelegate next);

    public sealed class DelegateMiddleware : IMiddleware
    {
        public DelegateMiddleware(NextDelegate method)
        {
            this.Method = method ?? throw new ArgumentNullException(nameof(method));
        }

        private NextDelegate Method { get; }

        public Task InvokeAsync(IHttpContext context, IMiddlewareDelegate next)
        {
            return this.Method.Invoke(context, next);
        }
    }
}