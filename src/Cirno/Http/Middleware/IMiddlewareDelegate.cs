using System;
using System.Threading.Tasks;

namespace Cirno.Http.Middleware
{
    public interface IMiddlewareDelegate
    {
        Task InvokeAsync(IHttpContext context);
    }
}