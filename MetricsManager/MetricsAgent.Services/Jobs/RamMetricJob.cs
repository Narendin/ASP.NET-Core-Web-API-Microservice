using MetricsAgent.Entities.Metrics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgent.Services.Jobs
{
    public class RamMetricJob : BaseMetricJob<RamMetric>
    {
        public RamMetricJob(IServiceProvider serviceProvider)
            : base(serviceProvider, new PerformanceCounter("Memory", "Available MBytes"))
        {
        }
    }
}