using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Cirno.Http;

namespace Cirno.DotNetty
{
    // TODO 找个时间来完成与DotNetty的适配
    public class DotNettyHttpServer : IHttpServer
    {
        public Task CloseAsync()
        {
            throw new NotImplementedException();
        }

        public Task ListenAsync(IPAddress address, int port)
        {
            throw new NotImplementedException();
        }

        public void UseHandler(IHttpHandler handler)
        {
            throw new NotImplementedException();
        }

        public void UseSsl(X509Certificate certificate)
        {
            throw new NotImplementedException();
        }
    }
}