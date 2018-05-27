using System;
using System.Collections.Generic;
using System.Linq;

namespace Cirno.Logging
{
    public class LogManager : ILogManager
    {
        private readonly List<ILoggerFactory> factories = new List<ILoggerFactory>();
        private readonly LogLevel minLevel;

        public LogManager() : this(LogLevel.Trace)
        {
        }

        public LogManager(LogLevel minLevel)
        {
            this.minLevel = minLevel;
        }

        public void Add(ILoggerFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            this.factories.Add(factory);
        }

        public ILogger GetLogger(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            var loggers = this.factories.Select(f => f.Create(name)).ToArray();
            return new CombinedLogger(loggers, this.minLevel);
        }
    }
}