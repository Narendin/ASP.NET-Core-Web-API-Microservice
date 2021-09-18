using System;

namespace MetricsAgent.Interfaces
{
    public interface IMetricDto
    {
        public DateTime Time { get; set; }
        public int Value { get; set; }
    }
}