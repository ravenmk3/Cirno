using System;

namespace Cirno.Http.Middleware
{
    public interface IMiddlewarePipeline
    {
        IMiddlewarePipeline AddLast(IMiddleware middleware);
    }
}