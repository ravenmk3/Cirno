using System;
using System.Threading.Tasks;

namespace Cirno.Http
{
    public interface IHttpHandler
    {
        Task HandleAsync(IHttpContext context);
    }
}