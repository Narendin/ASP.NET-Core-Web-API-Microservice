using MetricsManager.Entities;

namespace MetricsAgent.Interfaces
{
    /// <summary>
    /// Репозиторий для метрик сети
    /// </summary>
    public interface INetworkMetricsRepository : IRepository<NetworkMetric>
    {
    }
}