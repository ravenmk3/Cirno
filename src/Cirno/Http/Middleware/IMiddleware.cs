using System;
using System.Threading.Tasks;

namespace Cirno.Http.Middleware
{
    public interface IMiddleware
    {
        Task InvokeAsync(IHttpContext context, IMiddlewareDelegate next);
    }
}