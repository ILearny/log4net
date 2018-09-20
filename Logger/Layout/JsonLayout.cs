using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Layout
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent);
            writer.WriteLine(json);
        }
    }
}


class SerializableLogEvent
{
    public SerializableLogEvent(LoggingEvent loggingEvent)
    {
        this.Message = loggingEvent.MessageObject.ToString();
        this.Exception = loggingEvent.GetExceptionString();
    }

    public string Message { get; set; }
    public string Exception { get; set; }
}