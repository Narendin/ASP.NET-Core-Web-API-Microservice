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
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;
        private Mock<IRepository<HddMetric>> mock;
        private Mock<ILogger<HddMetricsController>> loggerMock;

        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IRepository<HddMetric>>();
            loggerMock = new Mock<ILogger<HddMetricsController>>();
            _controller = new HddMetricsController(loggerMock.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();
            var result = _controller.Create(new HddMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
    }
}