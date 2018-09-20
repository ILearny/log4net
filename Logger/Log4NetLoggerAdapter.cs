using System;
using System.IO;
using System.Reflection;
using log4net;
using Logger.Enums;
using Logger.Models;

namespace Logger
{
    public class Log4NetLoggerAdapter
    {
        private readonly ILog _logger;

        public Log4NetLoggerAdapter()
        {
            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, new FileInfo("log4net.config"));
            GlobalContext.Properties["GlobalConfig"] = "GlobalValue";
            //ThreadContext
        }

        public void Log(LogEntry entry)
        {
            var _logger = LogManager.GetLogger(entry.CallingType);
            switch (entry.Severity)
            {
                case LoggingEventType.Debug:
                    if(_logger.IsDebugEnabled)
                        _logger.Debug(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Information:
                    if (_logger.IsInfoEnabled)
                        _logger.Info(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Warning:
                    if (_logger.IsWarnEnabled)
                        _logger.Warn(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Error:
                    if (_logger.IsErrorEnabled)
                        _logger.Error(entry.Message, entry.Exception);
                    break;
                case LoggingEventType.Fatal:
                    if (_logger.IsFatalEnabled)
                        _logger.Fatal(entry.Message, entry.Exception);
                    break;
                default:
                    _logger.Warn($"Encountered unknown log level {entry.Severity}, writing out as Info.");
                    _logger.Info(entry.Message, entry.Exception);
                    break;
            }
        }
    }
}
