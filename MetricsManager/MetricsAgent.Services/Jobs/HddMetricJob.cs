using MetricsAgent.Entities.Metrics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgent.Services.Jobs
{
    public class HddMetricJob : BaseMetricJob<HddMetric>
    {
        public HddMetricJob(IServiceProvider serviceProvider)
            : base(serviceProvider, new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total"))
        {
        }
    }
}