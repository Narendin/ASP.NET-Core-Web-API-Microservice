using MetricsAgent.Entities.Metrics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgent.Services.Jobs
{
    public class DotNetMetricJob : BaseMetricJob<DotNetMetric>
    {
        public DotNetMetricJob(IServiceProvider serviceProvider)
            : base(serviceProvider, new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps", "_Global_"))
        {
        }
    }
}