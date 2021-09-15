using MetricsAgent.DB;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.Repositories
{
    /// <summary>
    /// Базовый абстрактный репозиторий
    /// </summary>
    /// <typeparam name="TMetric">Тип метрик</typeparam>
    public class SqlLiteMetricRepository<TMetric> : IRepository<TMetric> where TMetric : class, IMetric, new()
    {
        public readonly ILogger<SqlLiteMetricRepository<TMetric>> _logger;
        private const string ConnectionString = SQLiteConfigure.ConnectionString;

        public Table TableName { get; set; }

        public SqlLiteMetricRepository(ILogger<SqlLiteMetricRepository<TMetric>> logger)
        {
            // Здесь надо подумать, нужен ли логер вообще в репозитории. Пока нигде не используется.
            _logger = logger;
        }

        /// <summary>
        /// Получение выдержки из БД за указанный период
        /// </summary>
        /// <param name="fromTime">Начало периода</param>
        /// <param name="toTime">Конец периода</param>
        /// <returns>Лист метрик либо null</returns>
        public IList<TMetric> GetByTimePeriod(DateTime fromTime, DateTime toTime)
        {
            var fromSeconds = new DateTimeOffset(fromTime).ToUnixTimeSeconds();
            var toSeconds = new DateTimeOffset(toTime).ToUnixTimeSeconds();
            if (fromSeconds > toSeconds)
            {
                return null;
            }

            var temp = new List<TMetric>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM " + TableName.ToString() + " WHERE (time >= @from) and (time <= @to) ORDER BY time, id";
                    cmd.Parameters.AddWithValue("@from", fromSeconds);
                    cmd.Parameters.AddWithValue("@to", toSeconds);
                    cmd.Prepare();

                    connection.Open();

                    using var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        temp.Add(new TMetric()
                        {
                            Id = reader.GetInt32(0),
                            Value = reader.GetInt32(1),
                            Time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(reader.GetInt64(2))
                        });
                    }
                }
            }
            return temp.Count > 0 ? temp : null;
        }
    }
}