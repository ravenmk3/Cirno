using System;

namespace Cirno.Logging.Console
{
    public static class LogManagerExtensions
    {
        public static ILogManager AddConsole(this ILogManager logManager, LogLevel minLevel)
        {
            if (logManager == null)
            {
                throw new ArgumentNullException(nameof(logManager));
            }
            logManager.Add(new ConsoleLoggerFactory(minLevel));
            return logManager;
        }

        public static ILogManager AddConsole(this ILogManager logManager)
        {
            if (logManager == null)
            {
                throw new ArgumentNullException(nameof(logManager));
            }
            logManager.Add(new ConsoleLoggerFactory());
            return logManager;
        }
    }
}