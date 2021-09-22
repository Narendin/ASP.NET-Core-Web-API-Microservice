using MetricsAgent.Entities.Metrics;
using System;
using System.Diagnostics;

namespace MetricsAgent.Services.Jobs
{
    public class CpuMetricJob : BaseMetricJob<CpuMetric>
    {
        public CpuMetricJob(IServiceProvider serviceProvider)
            : base(serviceProvider, new PerformanceCounter("Processor", "% Processor Time", "_Total"))
        {
        }
    }
}