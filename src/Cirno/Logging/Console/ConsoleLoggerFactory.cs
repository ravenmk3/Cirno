using System;

namespace Cirno.Logging.Console
{
    public class ConsoleLoggerFactory : ILoggerFactory
    {
        private readonly LogLevel minLevel;

        public ConsoleLoggerFactory() : this(LogLevel.Trace)
        {
        }

        public ConsoleLoggerFactory(LogLevel minLevel)
        {
            this.minLevel = minLevel;
        }

        public ILogger Create(string name)
        {
            return new ConsoleLogger(name, this.minLevel);
        }
    }
}