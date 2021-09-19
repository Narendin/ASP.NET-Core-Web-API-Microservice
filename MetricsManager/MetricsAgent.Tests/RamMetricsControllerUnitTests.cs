using MetricsAgent.Controllers;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;

namespace MetricsAgent.Tests
{
    /// <summary>
    /// Тестирование контроллера метрик оперативной памяти
    /// </summary>
    public class RamMetricsControllerUnitTests : BaseMetricsControllerUnitTests<RamMetricsController, RamMetric, RamMetricDto>
    {
    }
}