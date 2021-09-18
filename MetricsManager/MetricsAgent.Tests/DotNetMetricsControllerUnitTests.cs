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
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;

        private Mock<IRepository<DotNetMetric>> mock;
        private Mock<ILogger<DotNetMetricsController>> loggerMock;

        public DotNetMetricsControllerUnitTests()
        {
            mock = new Mock<IRepository<DotNetMetric>>();
            loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _controller = new DotNetMetricsController(loggerMock.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            var result = _controller.Create(new DotNetMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }
    }
}