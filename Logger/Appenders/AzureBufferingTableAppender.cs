using System;
using System.Linq;
using log4net.Appender;
using log4net.Core;
using Logger.Configuration;
using Logger.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Logger.Appenders
{
    public class AzureBufferingTableAppender : BufferingAppenderSkeleton
    {
        public AzureBufferingTableAppender()
        {
            Setup();
        }

        private void Setup()
        {
            this._connectionString = ConfigurationManager.LoggingConfigurationSettings.AzureConnectionString;
            this._tableName = ConfigurationManager.LoggingConfigurationSettings.AzureTableName;
        }

        private CloudStorageAccount _account;
        private CloudTableClient _client;
        private CloudTable _table;

        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                    throw new ApplicationException("log4Net => AzureConnectionStringNotSpecified");
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        private string _tableName;

        public string TableName
        {
            get
            {
                if (String.IsNullOrEmpty(_tableName))
                    throw new ApplicationException("log4Net => TableNameNotSpecified");
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }

        protected override void SendBuffer(LoggingEvent[] events)
        {
            var grouped = events.GroupBy(evt => evt.LoggerName);
            foreach (var group in grouped)
            {
                var batchOperation = new TableBatchOperation();
                foreach (var azureLoggingEvent in group.Select(@event => new AzureLoggingEventEntity(@event)))
                {
                    batchOperation.Insert(azureLoggingEvent);
                }
                _table.ExecuteBatchAsync(batchOperation);
            }
        }

        public override void ActivateOptions()
        {
            base.ActivateOptions();

            _account = CloudStorageAccount.Parse(ConnectionString);
            _client = _account.CreateCloudTableClient();
            _table = _client.GetTableReference(TableName);
            _table.CreateIfNotExistsAsync();
        }
    }
}
