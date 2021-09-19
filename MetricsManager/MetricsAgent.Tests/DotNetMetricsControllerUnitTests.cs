using MetricsAgent.Controllers;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;

namespace MetricsAgent.Tests
{
    /// <summary>
    /// Тестирование контроллера метрик DotNet
    /// </summary>
    public class DotNetMetricsControllerUnitTests : BaseMetricsControllerUnitTests<DotNetMetricsController, DotNetMetric, DotNetMetricDto>
    {
    }
}