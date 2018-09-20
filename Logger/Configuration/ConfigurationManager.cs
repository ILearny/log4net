using Microsoft.Extensions.Configuration;
using System.IO;

namespace Logger.Configuration
{
    public static class ConfigurationManager
    {
        private static IConfigurationRoot appSettings;
        public static ILoggingConfigurationSettings LoggingConfigurationSettings { get; }

        static ConfigurationManager()
        {
            appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            LoggingConfigurationSettings = appSettings.GetSection("LoggingConfigurationSettings").Get<LoggingConfigurationSettings>();
            appSettings.Reload();
        }
    }
}
