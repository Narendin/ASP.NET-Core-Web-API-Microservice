using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Repositories
{
    /// <summary>
    /// Репозиторий метрик сети
    /// </summary>
    public class NetworkMetricsRepository : BaseMetricsRepository<NetworkMetric>, INetworkMetricsRepository
    {
        public NetworkMetricsRepository(ILogger<NetworkMetricsRepository> logger) : base(logger)
        {
        }
    }
}