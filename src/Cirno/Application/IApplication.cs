using System;
using System.Threading.Tasks;

namespace Cirno.Application
{
    public interface IApplication
    {
        IServiceProvider Services { get; }

        Task StopAsync();
    }
}