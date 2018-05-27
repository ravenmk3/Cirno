using System;

namespace Cirno.Logging
{
    public static class LoggerExtensions
    {
        public static void Trace(this ILogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Trace, message, args);
        }

        public static void Trace(this ILogger logger, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Trace, exception, message, args);
        }

        public static void Debug(this ILogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Debug, message, args);
        }

        public static void Debug(this ILogger logger, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Debug, exception, message, args);
        }

        public static void Info(this ILogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Info, message, args);
        }

        public static void Info(this ILogger logger, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Info, exception, message, args);
        }

        public static void Warning(this ILogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Warning, message, args);
        }

        public static void Warning(this ILogger logger, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Warning, exception, message, args);
        }

        public static void Error(this ILogger logger, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Error, message, args);
        }

        public static void Error(this ILogger logger, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            logger.Log(LogLevel.Error, exception, message, args);
        }
    }
}