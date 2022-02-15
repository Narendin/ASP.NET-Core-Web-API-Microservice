using MetricsManager.DB;
using MetricsManager.DB.Interfaces;
using MetricsManager.Dto;
using MetricsManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера получения метрик dotNet с агента
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DotNetMetricsController : BaseMetricsController<DotNetMetricDto>
    {
        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger,
            IDbRepository<AgentInfo> repository,
            IMetricMapper mapper)
            : base(logger, repository, mapper)
        {
        }
    }
}