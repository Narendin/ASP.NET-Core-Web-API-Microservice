using MetricsManager.DB;
using MetricsManager.DB.Interfaces;
using MetricsManager.Dto;
using MetricsManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера получения метрик оперативной памяти с агента
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RamMetricsController : BaseMetricsController<RamMetricDto>
    {
        public RamMetricsController(ILogger<RamMetricsController> logger,
            IDbRepository<AgentInfo> repository,
            IMetricMapper mapper)
            : base(logger, repository, mapper)
        {
        }
    }
}