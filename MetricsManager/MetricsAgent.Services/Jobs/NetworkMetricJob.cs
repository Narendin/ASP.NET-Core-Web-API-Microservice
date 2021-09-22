using MetricsAgent.Entities.Metrics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgent.Services.Jobs
{
    public class NetworkMetricJob : BaseMetricJob<NetworkMetric>
    {
        public NetworkMetricJob(IServiceProvider serviceProvider)
            : base(serviceProvider, new PerformanceCounter("Network Adapter", "Bytes Total/sec", "WAN Miniport [Network Monitor]"))
        {
        }
    }
}