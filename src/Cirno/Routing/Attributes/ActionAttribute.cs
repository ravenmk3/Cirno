using System;
using Cirno.Http;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class ActionAttribute : Attribute
    {
        public ActionAttribute(HttpMethod method)
        {
            this.Method = method;
        }

        public ActionAttribute(HttpMethod method, string template)
        {
            this.Method = method;
            this.Template = template;
        }

        public ActionAttribute(HttpMethod method, string template, int order)
        {
            this.Method = method;
            this.Template = template;
            this.Order = order;
        }

        public HttpMethod Method { get; }

        public string Template { get; set; }

        public int Order { get; set; }
    }
}