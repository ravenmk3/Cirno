using System;
using System.Threading.Tasks;
using Cirno.Http;
using Cirno.Http.Middleware;
using Cirno.Http.Responses;
using Cirno.Routing;

namespace Cirno.Mvc
{
    public class MvcMiddleware : IMiddleware
    {
        public MvcMiddleware(IRouter router)
        {
            this.Router = router;
        }

        public IRouter Router { get; }

        public async Task InvokeAsync(IHttpContext context, IMiddlewareDelegate next)
        {
            var result = this.Router.Route(context.Request.Path.Trim('/'), context.Request.Method);
            if (result.Handler != null)
            {
                await result.Handler.HandleAsync(context);
            }
            else
            {
                context.Response = new NotFoundResponse();
            }
            await next.InvokeAsync(context);
        }
    }
}