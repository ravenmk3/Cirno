using System;

namespace Cirno.Logging.Console
{
    public class ConsoleLogger : ILogger
    {
        private readonly string name;
        private readonly LogLevel minLevel;

        public ConsoleLogger(string name) : this(name, LogLevel.Trace)
        {
            this.name = name;
        }

        public ConsoleLogger(string name, LogLevel minLevel)
        {
            this.name = name;
            this.minLevel = minLevel;
        }

        public void Log(LogLevel level, string message, params object[] args)
        {
            if (level < this.minLevel)
            {
                return;
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            System.Console.WriteLine("[{0}][{1:yyyy-MM-dd HH:mm:ss}][{2}] {3}",
                level,
                DateTime.Now,
                this.name,
                String.Format(message, args));
        }

        public void Log(LogLevel level, Exception exception, string message, params object[] args)
        {
            if (level < this.minLevel)
            {
                return;
            }
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            System.Console.WriteLine("[{0}][{1:yyyy-MM-dd HH:mm:ss}][{2}] {3}",
                level,
                DateTime.Now,
                this.name,
                String.Format(message, args));
            System.Console.WriteLine(exception.ToString());
        }
    }
}