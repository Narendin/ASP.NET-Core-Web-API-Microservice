using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик оперативной памяти
    /// </summary>
    [ApiController]
    [Route("api/metrics/ram")]
    public class RamMetricsController : Controller
    {
        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetAvailableRamFromManager([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}