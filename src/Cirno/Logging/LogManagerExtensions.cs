using System;

namespace Cirno.Logging
{
    public static class LogManagerExtensions
    {
        public static ILogger GetLogger(this ILogManager logManager, Type type)
        {
            if (logManager == null)
            {
                throw new ArgumentNullException(nameof(logManager));
            }
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            return logManager.GetLogger(type.FullName);
        }

        public static ILogger GetLogger<T>(this ILogManager logManager)
        {
            if (logManager == null)
            {
                throw new ArgumentNullException(nameof(logManager));
            }
            return logManager.GetLogger(typeof(T).FullName);
        }
    }
}