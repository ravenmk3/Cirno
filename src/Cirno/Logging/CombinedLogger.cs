using System;
using System.Collections.Generic;

namespace Cirno.Logging
{
    public sealed class CombinedLogger : ILogger
    {
        private readonly IEnumerable<ILogger> loggers;
        private readonly LogLevel minLevel;

        public CombinedLogger(IEnumerable<ILogger> loggers, LogLevel minLevel)
        {
            this.loggers = loggers ?? throw new ArgumentNullException(nameof(loggers));
            this.minLevel = minLevel;
        }

        public void Log(LogLevel level, string message, params object[] args)
        {
            if (level < this.minLevel)
            {
                return;
            }
            foreach (var logger in loggers)
            {
                logger.Log(level, message, args);
            }
        }

        public void Log(LogLevel level, Exception exception, string message, params object[] args)
        {
            if (level < this.minLevel)
            {
                return;
            }
            foreach (var logger in loggers)
            {
                logger.Log(level, exception, message, args);
            }
        }
    }
}