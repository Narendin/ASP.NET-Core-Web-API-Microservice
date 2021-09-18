using MetricsAgent.DB;
using MetricsAgent.Dto;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик жестких дисков
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HddMetricsController : BaseMetricsController<IRepository<HddMetric>, HddMetric, HddMetricDto>
    {
        public HddMetricsController(
            ILogger<HddMetricsController> logger,
            IRepository<HddMetric> repository,
            Table tableName = Table.hddmetrics) : base(logger, repository, tableName)
        {
            logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }
    }
}