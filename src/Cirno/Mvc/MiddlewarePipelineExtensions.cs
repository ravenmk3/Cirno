using System;
using Cirno.Http.Middleware;
using Cirno.Ioc;
using Cirno.Routing;

namespace Cirno.Mvc
{
    public static class MiddlewarePipelineExtensions
    {
        public static IMiddlewarePipeline AddMvc(this IMiddlewarePipeline pipeline, IRouter router)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            if (router == null)
            {
                throw new ArgumentNullException(nameof(router));
            }
            var middleware = new MvcMiddleware(router);
            pipeline.AddLast(middleware);
            return pipeline;
        }

        public static IMiddlewarePipeline AddMvc(this IMiddlewarePipeline pipeline, IServiceProvider provider)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            var router = provider.GetService<IRouter>();
            var middleware = new MvcMiddleware(router);
            pipeline.AddLast(middleware);
            return pipeline;
        }
    }
}