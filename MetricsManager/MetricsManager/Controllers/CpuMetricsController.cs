using MetricsManager.DB;
using MetricsManager.DB.Interfaces;
using MetricsManager.Dto;
using MetricsManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера получения метрик процессора с агента
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CpuMetricsController : BaseMetricsController<CpuMetricDto>
    {
        public CpuMetricsController(
            ILogger<CpuMetricsController> logger,
            IDbRepository<AgentInfo> repository,
            IMetricMapper mapper)
            : base(logger, repository, mapper)
        {
        }
    }
}