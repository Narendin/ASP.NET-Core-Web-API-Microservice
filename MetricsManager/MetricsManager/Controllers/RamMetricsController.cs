using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Контроллер менеджера сбора метрик оперативной памяти
    /// </summary>
    [ApiController]
    [Route("api/metrics/ram")]
    public class RamMetricsController : BaseMetricsController
    {
    }
}