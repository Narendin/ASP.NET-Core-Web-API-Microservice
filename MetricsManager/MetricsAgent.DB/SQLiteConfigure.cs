using System;
using System.Data.SQLite;

namespace MetricsAgent.DB
{
    public static class SQLiteConfigure
    {
        public const string ConnectionString = "Data Source=Metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public static void ConfigureSqlLiteConnection()
        {
            const string connectionString = ConnectionString;
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            foreach (var tableName in Enum.GetNames(typeof(Table)))
            {
                CreateTable(tableName, connection);
            }
            connection.Close();
        }

        public static void CreateTable(string tableName, SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
                var isTableExists = (long)command.ExecuteScalar() == 1;

                if (isTableExists)
                {
                    return;
                }

                command.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " (id INTEGER PRIMARY KEY, value INT, time LONG)";
                command.ExecuteNonQuery();

                Random rnd = new Random();
                int maxRnd = rnd.Next(100);
                for (int i = 1; i <= 10; i++)
                {
                    command.CommandText = "INSERT INTO " + tableName + " (value,time) VALUES (@value,@time);";
                    command.Parameters.AddWithValue("@value", rnd.Next(maxRnd));
                    command.Parameters.AddWithValue("@time", new DateTimeOffset(new DateTime(2021, 5, rnd.Next(1, 31), 0, 0, 0, 0, DateTimeKind.Utc)).ToUnixTimeSeconds());
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}