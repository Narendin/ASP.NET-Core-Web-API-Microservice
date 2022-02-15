using System;

namespace MetricsManager.Dto
{
    /// <summary>
    /// Базовый класс Dto метрик
    /// </summary>
    public class BaseMetricDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Время и дата
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public int Value { get; set; }
    }
}