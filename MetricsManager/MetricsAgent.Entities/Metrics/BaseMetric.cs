using System;

namespace MetricsAgent.Entities.Metrics
{
    /// <summary>
    /// Базовый класс для метрик
    /// </summary>
    public class BaseMetric
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Датаи время
        /// </summary>
        public DateTime Time { get; set; }
    }
}