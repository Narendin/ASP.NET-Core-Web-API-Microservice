using MetricsManager.Entities;

namespace MetricsAgent.Interfaces
{
    /// <summary>
    /// Репозиторий для метрик оперативной памяти
    /// </summary>
    public interface IRamMetricsRepository : IRepository<RamMetric>
    {
    }
}