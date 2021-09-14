using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик жестких дисков
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HddMetricsController : BaseMetricsController<IHddMetricsRepository, HddMetric>
    {
        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository repository) : base(logger, repository)
        {
            _logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }
    }
}