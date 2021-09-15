using MetricsManager.Entities.Interfaces;
using System;

namespace MetricsManager.Entities.Metrics
{
    public class RamMetric : IMetric
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}