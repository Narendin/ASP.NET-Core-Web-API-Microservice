using MetricsAgent.Controllers;
using MetricsAgent.DB.Interfaces;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgent.Tests
{
    /// <summary>
    /// Тестирование контроллера метрик сети
    /// </summary>
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;
        private Mock<IDbRepository<NetworkMetric>> mock;
        private Mock<ILogger<NetworkMetricsController>> loggerMock;
        private MetricMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public NetworkMetricsControllerUnitTests()
        {
            mock = new Mock<IDbRepository<NetworkMetric>>();
            loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _mapper = new MetricMapper();
            _controller = new NetworkMetricsController(loggerMock.Object, mock.Object, _mapper);
        }

        /// <summary>
        /// Тестирование контроллера метрик сети
        /// </summary>
        [Fact]
        public void Create_ShouldCall_AddAsync_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.AddAsync(It.IsAny<NetworkMetric>())).Verifiable();
            var result = _controller.Create(new NetworkMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.AddAsync(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }
    }
}