using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Configuration
{
    public interface ILoggingConfigurationSettings
    {
        string AzureConnectionString { get; }
        string AzureTableName { get; }
    }
}
