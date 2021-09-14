using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера сбора метрик dotNet
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DotNetMetricsController : BaseMetricsController
    {
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger) : base(logger)
        {
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        }
    }
}