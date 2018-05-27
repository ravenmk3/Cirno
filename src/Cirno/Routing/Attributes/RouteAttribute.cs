using System;

namespace Cirno.Routing.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class RouteAttribute : Attribute
    {
        public RouteAttribute()
        {
        }

        public RouteAttribute(string template)
        {
            this.Template = template;
        }

        public RouteAttribute(string template, int order)
        {
            this.Template = template;
            this.Order = order;
        }

        public string Template { get; set; }

        public int Order { get; set; }
    }
}