﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/metrics/hdd")]
    public class HddMetricsController : BaseMetricsController
    {
    }
}