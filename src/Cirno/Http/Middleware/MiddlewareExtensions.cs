using System;

namespace Cirno.Http.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IMiddlewarePipeline Add(this IMiddlewarePipeline pipeline, NextDelegate method)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }
            pipeline.AddLast(new DelegateMiddleware(method));
            return pipeline;
        }
    }
}