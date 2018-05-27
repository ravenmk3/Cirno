using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class DeleteAttribute : ActionAttribute
    {
        public DeleteAttribute() : base(HttpMethod.Delete)
        {
        }

        public DeleteAttribute(string template) : base(HttpMethod.Delete, template)
        {
        }

        public DeleteAttribute(string template, int order) : base(HttpMethod.Delete, template, order)
        {
        }
    }
}