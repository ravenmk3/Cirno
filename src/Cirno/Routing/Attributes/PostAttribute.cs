using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class PostAttribute : ActionAttribute
    {
        public PostAttribute() : base(HttpMethod.Post)
        {
        }

        public PostAttribute(string template) : base(HttpMethod.Post, template)
        {
        }

        public PostAttribute(string template, int order) : base(HttpMethod.Post, template, order)
        {
        }
    }
}