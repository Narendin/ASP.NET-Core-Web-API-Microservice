using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик процессора
    /// </summary>
    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuMetricsController : Controller
    {
        [HttpGet("/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromManager([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}