using System;

namespace Cirno.Logging
{
    public interface ILoggerFactory
    {
        ILogger Create(string name);
    }
}