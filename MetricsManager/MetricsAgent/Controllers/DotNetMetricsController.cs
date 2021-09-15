using MetricsAgent.DB;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик dotNet
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DotNetMetricsController : BaseMetricsController<IRepository<DotNetMetric>, DotNetMetric>
    {
        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger,
            IRepository<DotNetMetric> repository,
            Table tableName = Table.dotnetmetrics) : base(logger, repository, tableName)
        {
            logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }
    }
}