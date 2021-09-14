using MetricsManager.Entities;

namespace MetricsAgent.Interfaces
{
    /// <summary>
    /// Репозиторий для метрик dotNet
    /// </summary>
    public interface IDotNetMetricsRepository : IRepository<DotNetMetric>
    {
    }
}