using System;
using System.Reflection;
using Cirno.Http;

namespace Cirno.Mvc.Discovery
{
    public class ActionDescription
    {
        public string UriTemplate { get; set; }

        public HttpMethod Method { get; set; }

        public int Order { get; set; }

        public Type ControllerType { get; set; }

        public MethodInfo ActionMethod { get; set; }
    }
}