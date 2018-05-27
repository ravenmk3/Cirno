using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Cirno.Application
{
    public interface IBootstrapper
    {
        IBootstrapper Bind(IPAddress address, int port);

        IBootstrapper UseSsl(X509Certificate certificate);

        Task<IApplication> RunAsync();
    }
}