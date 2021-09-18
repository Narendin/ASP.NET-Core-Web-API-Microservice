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
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;
        private Mock<IRepository<NetworkMetric>> mock;
        private Mock<ILogger<NetworkMetricsController>> loggerMock;

        public NetworkMetricsControllerUnitTests()
        {
            mock = new Mock<IRepository<NetworkMetric>>();
            loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _controller = new NetworkMetricsController(loggerMock.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();
            var result = _controller.Create(new NetworkMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }
    }
}