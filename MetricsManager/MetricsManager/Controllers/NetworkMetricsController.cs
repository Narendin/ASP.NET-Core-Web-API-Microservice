using MetricsManager.DB;
using MetricsManager.DB.Interfaces;
using MetricsManager.Dto;
using MetricsManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера получения метрик сети с агента
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkMetricsController : BaseMetricsController<NetworkMetricDto>
    {
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger,
            IDbRepository<AgentInfo> repository,
            IMetricMapper mapper)
            : base(logger, repository, mapper)
        {
        }
    }
}