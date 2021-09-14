using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик dotNet
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DotNetMetricsController : BaseMetricsController<IDotNetMetricsRepository, DotNetMetric>
    {
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IDotNetMetricsRepository repository) : base(logger, repository)
        {
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }
    }
}