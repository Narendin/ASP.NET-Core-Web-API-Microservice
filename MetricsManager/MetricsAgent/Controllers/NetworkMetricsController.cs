using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик сети
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkMetricsController : BaseMetricsController<INetworkMetricsRepository, NetworkMetric>
    {
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, INetworkMetricsRepository repository) : base(logger, repository)
        {
            _logger.LogDebug(1, "NLog встроен в NetworkMetricsController");
        }
    }
}