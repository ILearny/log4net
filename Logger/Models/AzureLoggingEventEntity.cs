using System;
using System.Globalization;
using Microsoft.WindowsAzure.Storage.Table;
using log4net.Core;

namespace Logger.Models
{
    internal sealed class AzureLoggingEventEntity : TableEntity
    {
        public AzureLoggingEventEntity(LoggingEvent e)
        {
            Level = e.Level.Name;
            LoggerName = e.LoggerName;
            Message = e.RenderedMessage;
            Exception = e.GetExceptionString();
            ThreadName = e.ThreadName;
            UserName = e.UserName;

            PartitionKey = e.LoggerName;
            RowKey = MakeRowKey(e);
        }

        private static string MakeRowKey(LoggingEvent loggingEvent)
        {
            return Guid.NewGuid().ToString().ToLower();
        }

        public string Level { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

        public string ThreadName { get; set; }
        public string LoggerName { get; set; }
        public string UserName { get; set; }

    }
}
