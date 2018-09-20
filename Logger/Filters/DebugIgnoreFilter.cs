using log4net.Core;
using log4net.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Filters
{
    public class DebugIgnoreFilter : FilterSkeleton
    {
        public override FilterDecision Decide(LoggingEvent loggingEvent)
        {
            if (loggingEvent.Level != Level.Debug) 
            {
                return FilterDecision.Neutral;
            }

            if (loggingEvent.MessageObject.ToString().Contains("Ignore"))
            {
                return FilterDecision.Deny;
            }

            return FilterDecision.Accept;
        }
    }
}
