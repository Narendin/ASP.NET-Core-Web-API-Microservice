using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик жестких дисков
    /// </summary>
    [ApiController]
    [Route("api/metrics/hdd")]
    public class HddMetricsController : Controller
    {
        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public IActionResult GetLeftFromManager([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}