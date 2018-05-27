using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class PatchAttribute : ActionAttribute
    {
        public PatchAttribute() : base(HttpMethod.Patch)
        {
        }

        public PatchAttribute(string template) : base(HttpMethod.Patch, template)
        {
        }

        public PatchAttribute(string template, int order) : base(HttpMethod.Patch, template, order)
        {
        }
    }
}