using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class OptionAttribute : ActionAttribute
    {
        public OptionAttribute() : base(HttpMethod.Option)
        {
        }

        public OptionAttribute(string template) : base(HttpMethod.Option, template)
        {
        }

        public OptionAttribute(string template, int order) : base(HttpMethod.Option, template, order)
        {
        }
    }
}