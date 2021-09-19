using MetricsAgent.Controllers;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;

namespace MetricsAgent.Tests
{
    /// <summary>
    /// Тестирование контроллера метрик процессора
    /// </summary>
    public class CpuMetricsControllerUnitTests : BaseMetricsControllerUnitTests<CpuMetricsController, CpuMetric, CpuMetricDto>
    {
    }
}