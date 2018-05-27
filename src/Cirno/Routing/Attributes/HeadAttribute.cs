using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class HeadAttribute : ActionAttribute
    {
        public HeadAttribute() : base(HttpMethod.Head)
        {
        }

        public HeadAttribute(string template) : base(HttpMethod.Head, template)
        {
        }

        public HeadAttribute(string template, int order) : base(HttpMethod.Head, template, order)
        {
        }
    }
}