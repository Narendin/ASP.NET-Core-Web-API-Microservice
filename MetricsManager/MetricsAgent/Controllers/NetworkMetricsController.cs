using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик сети
    /// </summary>
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : Controller
    {
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetworkDataFromManager([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}