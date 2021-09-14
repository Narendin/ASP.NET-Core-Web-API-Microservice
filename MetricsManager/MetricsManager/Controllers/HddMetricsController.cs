using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера сбора метрик жестких дисков
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HddMetricsController : BaseMetricsController
    {
        public HddMetricsController(ILogger<BaseMetricsController> logger) : base(logger)
        {
            _logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }
    }
}