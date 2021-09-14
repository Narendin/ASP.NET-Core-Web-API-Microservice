using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Repositories
{
    /// <summary>
    /// Репозиторий метрик жестких дисков
    /// </summary>
    public class HddMetricsRepository : BaseMetricsRepository<HddMetric>, IHddMetricsRepository
    {
        public HddMetricsRepository(ILogger<HddMetricsRepository> logger) : base(logger)
        {
        }
    }
}