using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Repositories
{
    /// <summary>
    /// Репозиторий метрик процессора
    /// </summary>
    public class CpuMetricsRepository : BaseMetricsRepository<CpuMetric>, ICpuMetricsRepository
    {
        public CpuMetricsRepository(ILogger<CpuMetricsRepository> logger) : base(logger)
        {
        }
    }
}