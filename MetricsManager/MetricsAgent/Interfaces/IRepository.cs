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
        IList<T> GetByTimePeriod(DateTime fromTime, DateTime toTime);
    }
}