using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class PutAttribute : ActionAttribute
    {
        public PutAttribute() : base(HttpMethod.Put)
        {
        }

        public PutAttribute(string template) : base(HttpMethod.Put, template)
        {
        }

        public PutAttribute(string template, int order) : base(HttpMethod.Put, template, order)
        {
        }
    }
}