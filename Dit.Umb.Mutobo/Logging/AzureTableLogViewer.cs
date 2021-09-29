using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Serilog.Events;
using Serilog.Formatting.Compact.Reader;
using Serilog.Sinks.AzureTableStorage;
using StackExchange.Profiling.Internal;
using Umbraco.Core.Logging.Viewer;

namespace Dit.Umb.Mutobo.Logging
{
    public class AzureTableLogViewer : LogViewerSourceBase
    {
        public override bool CanHandleLargeLogs => true;

        public override bool CheckCanOpenLogs(LogTimePeriod logTimePeriod)
        {
            //this method will not be called as we have indicated that this 'CanHandleLargeLogs'
            throw new NotImplementedException();
        }

        protected override IReadOnlyList<LogEvent> GetLogs(LogTimePeriod logTimePeriod, ILogFilter filter, int skip, int take)
        {

            var configService =
                (IConfigurationService) DependencyResolver.Current.GetService(typeof(IConfigurationService));

            var connectionString =
                ConfigurationManager.AppSettings["AzureConnectionString"];
            var tableName = ConfigurationManager.AppSettings["LogStorageTableName"];

            var cloudStorage = CloudStorageAccount.Parse(connectionString);
            var tableClient = cloudStorage.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);

            var logs = new List<LogEvent>();
            var count = 0;

            var query = new TableQuery<LogEventEntity>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, logTimePeriod.StartTime.Date),
                    TableOperators.And,
                    TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.LessThanOrEqual, logTimePeriod.EndTime.Date.AddDays(1).AddSeconds(-1))
                    )
                );

            var results = table.ExecuteQuery(query);

            foreach (var entity in results)
            {
                var logItem = LogEventReader.ReadFromString(entity.Data);


                

                if (count > skip + take)
                {
                    break;
                }

                if (count < skip)
                {
                    count++;
                    continue;
                }

                if (filter.TakeLogEvent(logItem))
                {
                    logs.Add(logItem);
                }

                count++;
            }

            return logs;
        }

        public override IReadOnlyList<SavedLogSearch> GetSavedSearches()
        {
            return base.GetSavedSearches();
        }

        public override IReadOnlyList<SavedLogSearch> AddSavedSearch(string name, string query)
        {
            return base.AddSavedSearch(name, query);
        }

        public override IReadOnlyList<SavedLogSearch> DeleteSavedSearch(string name, string query)
        {
            return base.DeleteSavedSearch(name, query);
        }
    }
}