using System;

namespace Cirno.Http.Middleware
{
    public interface IPipelineHttpHandler : IHttpHandler, IMiddlewarePipeline
    {
    }
}