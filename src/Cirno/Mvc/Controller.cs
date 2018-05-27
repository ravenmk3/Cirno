using System;
using Cirno.Http;
using Cirno.Mvc.Responses;

namespace Cirno.Mvc
{
    public abstract class Controller
    {
        public IServiceProvider Services { get; internal set; }

        public IHttpContext Context { get; internal set; }

        public IRequest Request { get; internal set; }

        protected IResponse Json(object data)
        {
            return new JsonResponse(data);
        }

        protected IResponse Text(string text)
        {
            return new TextResponse(text);
        }
    }
}