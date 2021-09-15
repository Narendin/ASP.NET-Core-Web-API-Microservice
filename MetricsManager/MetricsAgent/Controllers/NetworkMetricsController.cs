using MetricsAgent.DB;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик сети
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkMetricsController : BaseMetricsController<IRepository<NetworkMetric>, NetworkMetric>
    {
        public NetworkMetricsController(
            ILogger<NetworkMetricsController> logger,
            IRepository<NetworkMetric> repository,
            Table tableName = Table.networkmetrics) : base(logger, repository, tableName)
        {
            logger.LogDebug(1, "NLog встроен в NetworkMetricsController");
        }
    }
}