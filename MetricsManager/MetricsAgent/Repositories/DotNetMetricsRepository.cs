using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Repositories
{
    /// <summary>
    /// Репозиторий метрик dotNet
    /// </summary>
    public class DotNetMetricsRepository : BaseMetricsRepository<DotNetMetric>, IDotNetMetricsRepository
    {
        public DotNetMetricsRepository(ILogger<DotNetMetricsRepository> logger) : base(logger)
        {
        }
    }
}