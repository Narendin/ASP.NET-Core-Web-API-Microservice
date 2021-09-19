using MetricsAgent.Controllers;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;

namespace MetricsAgent.Tests
{
    /// <summary>
    /// Тестирование контроллера метрик жестких дисков
    /// </summary>
    public class HddMetricsControllerUnitTests : BaseMetricsControllerUnitTests<HddMetricsController, HddMetric, HddMetricDto>
    {
    }
}