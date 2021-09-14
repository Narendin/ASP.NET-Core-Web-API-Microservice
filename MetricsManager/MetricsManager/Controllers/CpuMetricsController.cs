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
    [Route("api/[controller]")]
    public class CpuMetricsController : BaseMetricsController
    {
        public CpuMetricsController(ILogger<CpuMetricsController> logger) : base(logger)
        {
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        public override IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var result = base.GetMetricsFromAgent(agentId, fromTime, toTime);
            _logger.LogInformation($"Получили метрики процессора  c {fromTime} по {toTime} от агента {agentId}");
            return result;
        }
    }
}