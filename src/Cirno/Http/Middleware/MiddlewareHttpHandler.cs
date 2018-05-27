using System;
using System.Threading.Tasks;

namespace Cirno.Http.Middleware
{
    public class MiddlewareHttpHandler : IPipelineHttpHandler
    {
        private MiddlewareNode first;
        private MiddlewareNode last;

        public Task HandleAsync(IHttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (this.first == null)
            {
                return Task.CompletedTask;
            }
            return this.first.InvokeAsync(context);
        }

        public IMiddlewarePipeline AddLast(IMiddleware middleware)
        {
            if (middleware == null)
            {
                throw new ArgumentNullException(nameof(middleware));
            }
            var node = new MiddlewareNode(middleware);
            if (this.first == null)
            {
                this.first = node;
            }
            else
            {
                this.last.SetNext(node);
            }
            this.last = node;
            return this;
        }

        private class MiddlewareNode
        {
            public IMiddleware Middleware { get; }

            private IMiddlewareDelegate Next { get; set; }

            public MiddlewareNode(IMiddleware middleware)
            {
                this.Middleware = middleware ?? throw new ArgumentNullException(nameof(middleware));
                this.Next = EmptyDelegate.Instance;
            }

            public void SetNext(MiddlewareNode node)
            {
                if (node == null)
                {
                    throw new ArgumentNullException(nameof(node));
                }
                this.Next = new NextDelegate(node);
            }

            public Task InvokeAsync(IHttpContext context)
            {
                return this.Middleware.InvokeAsync(context, this.Next);
            }
        }

        private class NextDelegate : IMiddlewareDelegate
        {
            public NextDelegate(MiddlewareNode node)
            {
                this.Node = node ?? throw new ArgumentNullException(nameof(node));
            }

            public MiddlewareNode Node { get; }

            public Task InvokeAsync(IHttpContext context)
            {
                return this.Node.InvokeAsync(context);
            }
        }

        private class EmptyDelegate : IMiddlewareDelegate
        {
            public static readonly EmptyDelegate Instance = new EmptyDelegate();

            public Task InvokeAsync(IHttpContext context)
            {
                return Task.CompletedTask;
            }
        }
    }
}