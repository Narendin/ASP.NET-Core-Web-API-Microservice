using MetricsAgent.DB;
using MetricsAgent.Dto;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Metrics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик процессора
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CpuMetricsController : BaseMetricsController<IRepository<CpuMetric>, CpuMetric, CpuMetricDto>
    {
        public CpuMetricsController(
            ILogger<CpuMetricsController> logger,
            IRepository<CpuMetric> repository,
            Table tableName = Table.cpumetrics) : base(logger, repository, tableName)
        {
            logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }
    }
}