using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class LogEntry
    {
        public readonly Exception Exception;
        public readonly string Message;
        public readonly Type CallingType;
        public readonly LoggingEventType Severity;

        public LogEntry(Type callingType, LoggingEventType severity, string message, Exception exception = null)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (message == string.Empty) throw new ArgumentException("empty", "message");

            CallingType = callingType;
            Severity = severity;
            Message = message;
            Exception = exception;
        }
    }
}
