using Logger.Enums;
using Logger.Models;
using System;

namespace Logger.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogInfo<T>(this ILoggerAdapter logger, string message)
        {
            LogInfo(logger, typeof(T), message);
        }

        public static void LogInfo(this ILoggerAdapter logger, Type callingType, string message)
        {
            Log(logger, callingType, LoggingEventType.Information, message);
        }

        public static void LogWarn<T>(this ILoggerAdapter logger, string message, Exception exception = null)
        {
            LogWarn(logger, typeof(T), message, exception);
        }

        public static void LogWarn(this ILoggerAdapter logger, Type callingType, string message, Exception exception = null)
        {
            Log(logger, callingType, LoggingEventType.Warning, message, exception);
        }

        public static void LogError<T>(this ILoggerAdapter logger, Exception exception)
        {
            LogError(logger, typeof(T), exception);
        }

        public static void LogError<T>(this ILoggerAdapter logger, string message, Exception exception)
        {
            LogError(logger, typeof(T), message, exception);
        }

        public static void LogError(this ILoggerAdapter logger, Type callingType, string message, Exception exception)
        {
            LogError(logger, callingType, exception, message);
        }

        private static void LogError(this ILoggerAdapter logger, Type callingType, Exception exception, string message = null)
        {
            Log(logger, callingType, LoggingEventType.Error, message ?? exception.Message, exception);
        }

        private static void Log(this ILoggerAdapter logger, Type type, LoggingEventType loggingEventType, string message,
            Exception exception = null)
        {
            logger.Log(new LogEntry(type, loggingEventType, message, exception));
        }
    }
}
