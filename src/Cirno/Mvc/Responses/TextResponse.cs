using System;
using System.Text;
using Cirno.Http;

namespace Cirno.Mvc.Responses
{
    public class TextResponse : Response
    {
        public const string TEXT_CONTENT_TYPE = "text/plain;charset=utf-8";

        public TextResponse(string text)
        {
            this.Headers["Content-Type"] = TEXT_CONTENT_TYPE;
            this.Body = new TextContent(text, Encoding.UTF8);
        }
    }
}