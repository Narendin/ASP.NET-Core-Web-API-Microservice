using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик оперативной памяти
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RamMetricsController : BaseMetricsController<IRamMetricsRepository, RamMetric>
    {
        public RamMetricsController(ILogger<RamMetricsController> logger, IRamMetricsRepository repository) : base(logger, repository)
        {
            _logger.LogDebug(1, "NLog встроен в RamMetricsController");
        }
    }
}