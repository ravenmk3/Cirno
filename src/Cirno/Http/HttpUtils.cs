using System;

namespace Cirno.Http
{
    public static class HttpUtils
    {
        public static HttpMethod ParseMethod(string value)
        {
            switch (value)
            {
                case "GET":
                    return HttpMethod.Get;

                case "POST":
                    return HttpMethod.Post;

                case "PUT":
                    return HttpMethod.Put;

                case "PATCH":
                    return HttpMethod.Patch;

                case "DELETE":
                    return HttpMethod.Delete;

                case "OPTION":
                    return HttpMethod.Option;

                case "HEAD":
                    return HttpMethod.Head;

                default:
                    return HttpMethod.Get;
            }
        }
    }
}