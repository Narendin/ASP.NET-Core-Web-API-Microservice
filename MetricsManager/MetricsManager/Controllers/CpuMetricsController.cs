using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера сбора метрик процессора
    /// </summary>
    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuMetricsController : BaseMetricsController
    {
        private readonly ILogger<CpuMetricsController> _logger;

        public CpuMetricsController(ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        public override IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var result = base.GetMetricsFromAgent(agentId, fromTime, toTime);
            _logger.LogInformation($"Получили метсрики процессора от агента {agentId}");
            return result;
        }
    }
}