using System;

namespace Cirno.Logging
{
    public interface ILogger
    {
        void Log(LogLevel level, string message, params object[] args);

        void Log(LogLevel level, Exception exception, string message, params object[] args);
    }
}