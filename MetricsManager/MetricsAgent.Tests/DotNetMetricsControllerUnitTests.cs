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
    /// Тестирование контроллера метрик DotNet
    /// </summary>
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;

        private Mock<IDbRepository<DotNetMetric>> mock;
        private Mock<ILogger<DotNetMetricsController>> loggerMock;
        private MetricMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public DotNetMetricsControllerUnitTests()
        {
            mock = new Mock<IDbRepository<DotNetMetric>>();
            loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _mapper = new MetricMapper();
            _controller = new DotNetMetricsController(loggerMock.Object, mock.Object, _mapper);
        }

        /// <summary>
        /// Проверка метода AddAsync репозитория метрик DotNet
        /// </summary>
        [Fact]
        public void Create_ShouldCall_AddAsync_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.AddAsync(It.IsAny<DotNetMetric>())).Verifiable();
            var result = _controller.Create(new DotNetMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.AddAsync(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }
    }
}