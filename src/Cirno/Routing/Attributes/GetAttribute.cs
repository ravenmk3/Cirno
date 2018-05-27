using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class GetAttribute : ActionAttribute
    {
        public GetAttribute() : base(HttpMethod.Get)
        {
        }

        public GetAttribute(string template) : base(HttpMethod.Get, template)
        {
        }

        public GetAttribute(string template, int order) : base(HttpMethod.Get, template, order)
        {
        }
    }
}