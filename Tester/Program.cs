using Logger;
using Logger.Enums;
using Logger.Models;
using System;

namespace Tester
{
    class Program
    {
        public static Log4NetLoggerAdapter _log4NetLoggerAdapter;

        static void Main(string[] args)
        {
            Console.WriteLine("Application Started ...");

            _log4NetLoggerAdapter = new Log4NetLoggerAdapter();

            // Debug
            var logEntry = new LogEntry(typeof(Program), LoggingEventType.Debug, $"Debug Message");
            _log4NetLoggerAdapter.Log(logEntry);
            
            // Debug : IgnoreFilter
            logEntry = new LogEntry(typeof(Program), LoggingEventType.Debug, $"Will be ignored because of DebugIgnoreFilter");
            _log4NetLoggerAdapter.Log(logEntry);

            // Info
            logEntry = new LogEntry(typeof(Program), LoggingEventType.Information, $"Info");
            _log4NetLoggerAdapter.Log(logEntry);

            // Warn
            logEntry = new LogEntry(typeof(Program), LoggingEventType.Warning, $"Warning !!");
            _log4NetLoggerAdapter.Log(logEntry);
            
            // Error
            logEntry = new LogEntry(typeof(Program), LoggingEventType.Error, $"Error Occured ");
            _log4NetLoggerAdapter.Log(logEntry);

            // Fatal
            logEntry = new LogEntry(typeof(Program), LoggingEventType.Fatal, $"Exception thrown", new ApplicationException("An exception occured"));
            _log4NetLoggerAdapter.Log(logEntry);

            Console.ReadLine();
        }
    }
}
