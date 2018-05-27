using System;
using System.Text;
using Cirno.Http;

namespace Cirno.Mvc.Responses
{
    public class JsonResponse : Response
    {
        public const string JSON_CONTENT_TYPE = "application/json;charset=utf-8";

        public JsonResponse(object data)
        {
            this.Headers["Content-Type"] = JSON_CONTENT_TYPE;
            this.Body = new JsonContent(data, Encoding.UTF8);
        }
    }
}