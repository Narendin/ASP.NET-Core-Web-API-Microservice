using MetricsAgent.DB;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозитория метрик
    /// </summary>
    /// <typeparam name="T">Тип метрик</typeparam>
    public interface IRepository<T> where T : class
    {
        Table TableName { get; set; }

        IList<T> GetByTimePeriod(DateTime fromTime, DateTime toTime);

        void Create(T metrics);
    }
}