using MetricsAgent.Interfaces;
using MetricsManager.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Контроллер агента сбора метрик процессора
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CpuMetricsController : BaseMetricsController<ICpuMetricsRepository, CpuMetric>
    {
        public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsRepository repository) : base(logger, repository)
        {
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }
    }
}