using MetricsAgent.DB;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик оперативной памяти
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RamMetricsController : BaseMetricsController<IRepository<RamMetric>, RamMetric>
    {
        public RamMetricsController(
            ILogger<RamMetricsController> logger,
            IRepository<RamMetric> repository,
            Table tableName = Table.rammetrics) : base(logger, repository, tableName)
        {
            logger.LogDebug(1, "NLog встроен в RamMetricsController");
        }
    }
}