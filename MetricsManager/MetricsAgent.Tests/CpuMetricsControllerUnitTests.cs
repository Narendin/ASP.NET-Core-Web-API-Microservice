using MetricsAgent.Controllers;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;

namespace MetricsAgent.Tests
{
    /// <summary>
    /// ������������ ����������� ������ ����������
    /// </summary>
    public class CpuMetricsControllerUnitTests : BaseMetricsControllerUnitTests<CpuMetricsController, CpuMetric, CpuMetricDto>
    {
    }
}