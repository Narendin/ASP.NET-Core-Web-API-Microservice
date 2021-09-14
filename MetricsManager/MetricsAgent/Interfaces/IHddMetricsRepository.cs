using MetricsManager.Entities;

namespace MetricsAgent.Interfaces
{
    /// <summary>
    /// Репозиторий для метрик жестких дисков
    /// </summary>
    public interface IHddMetricsRepository : IRepository<HddMetric>
    {
    }
}