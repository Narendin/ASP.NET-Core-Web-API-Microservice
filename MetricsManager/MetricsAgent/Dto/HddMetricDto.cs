using MetricsAgent.Interfaces;
using System;

namespace MetricsAgent.Dto
{
    public class HddMetricDto : IMetricDto
    {
        public DateTime Time { get; set; }
        public int Value { get; set; }
    }
}