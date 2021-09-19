using AutoMapper;
using MetricsAgent.DB.Interfaces;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;
using MetricsAgent.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик жестких дисков
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HddMetricsController : BaseMetricsController<HddMetric, HddMetricDto>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="repository">Репозиторий</param>
        /// <param name="mapper">Маппер</param>
        public HddMetricsController(
            ILogger<HddMetricsController> logger,
            IDbRepository<HddMetric> repository,
            IMetricMapper mapper) : base(logger, repository, mapper)
        {
            logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }
    }
}