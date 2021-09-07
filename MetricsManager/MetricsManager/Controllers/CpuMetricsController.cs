using Microsoft.AspNetCore.Mvc;
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
    }
}