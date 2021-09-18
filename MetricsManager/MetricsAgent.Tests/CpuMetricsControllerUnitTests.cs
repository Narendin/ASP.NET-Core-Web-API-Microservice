using MetricsAgent.Controllers;
using MetricsAgent.Dto;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Metrics;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgent.Tests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;
        private Mock<IRepository<CpuMetric>> mock;
        private Mock<ILogger<CpuMetricsController>> loggerMock;

        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<IRepository<CpuMetric>>();
            loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(loggerMock.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = _controller.Create(new CpuMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}