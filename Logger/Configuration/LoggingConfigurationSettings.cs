using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Configuration
{
    public class LoggingConfigurationSettings : ILoggingConfigurationSettings
    {
        public string AzureConnectionString { get; set; }
        public string AzureTableName { get; set; }
    }
}
