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
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        private Mock<IRepository<RamMetric>> mock;
        private Mock<ILogger<RamMetricsController>> loggerMock;

        public RamMetricsControllerUnitTests()
        {
            mock = new Mock<IRepository<RamMetric>>();
            loggerMock = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(loggerMock.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();
            var result = _controller.Create(new RamMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}