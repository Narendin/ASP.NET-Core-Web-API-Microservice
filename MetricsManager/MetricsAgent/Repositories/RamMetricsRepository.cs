using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Repositories
{
    /// <summary>
    /// Репозиторий метрик оперативной памяти
    /// </summary>
    public class RamMetricsRepository : BaseMetricsRepository<RamMetric>, IRamMetricsRepository
    {
        public RamMetricsRepository(ILogger<RamMetricsRepository> logger) : base(logger)
        {
        }
    }
}