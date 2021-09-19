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
    /// Контроллер агента сбора метрик dotNet
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DotNetMetricsController : BaseMetricsController<DotNetMetric, DotNetMetricDto>
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="repository">Репозиторий</param>
        /// <param name="mapper">Маппер</param>
        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger,
            IDbRepository<DotNetMetric> repository,
            IMetricMapper mapper) : base(logger, repository, mapper)
        {
            logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }
    }
}