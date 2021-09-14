using MetricsManager.Entities;

namespace MetricsAgent.Interfaces
{
    /// <summary>
    /// Интерфейс для репозитория метрик процессора
    /// </summary>
    public interface ICpuMetricsRepository : IRepository<CpuMetric>
    {
    }
}