using System;

namespace Cirno.Http.Responses
{
    public sealed class NotFoundResponse : Response
    {
        public NotFoundResponse()
        {
            this.Status = 404;
        }
    }
}