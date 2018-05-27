using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Cirno.Http
{
    public interface IHttpServer
    {
        void UseHandler(IHttpHandler handler);

        void UseSsl(X509Certificate certificate);

        Task ListenAsync(IPAddress address, int port);

        Task CloseAsync();
    }
}