using MetricsAgent.Controllers;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;

namespace MetricsAgent.Tests
{
    /// <summary>
    /// Тестирование контроллера метрик сети
    /// </summary>
    public class NetworkMetricsControllerUnitTests : BaseMetricsControllerUnitTests<NetworkMetricsController, NetworkMetric, NetworkMetricDto>
    {
    }
}