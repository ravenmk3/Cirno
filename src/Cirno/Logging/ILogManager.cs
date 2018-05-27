using System;

namespace Cirno.Logging
{
    public interface ILogManager
    {
        void Add(ILoggerFactory factory);

        ILogger GetLogger(string name);
    }
}