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
    /// Тестирование контроллера метрик жестких дисков
    /// </summary>
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;
        private Mock<IDbRepository<HddMetric>> mock;
        private Mock<ILogger<HddMetricsController>> loggerMock;
        private MetricMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IDbRepository<HddMetric>>();
            loggerMock = new Mock<ILogger<HddMetricsController>>();
            _mapper = new MetricMapper();
            _controller = new HddMetricsController(loggerMock.Object, mock.Object, _mapper);
        }

        /// <summary>
        /// Проверка метода AddAsync репозитория метрик жестких дисков
        /// </summary>
        [Fact]
        public void Create_ShouldCall_AddAsync_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.AddAsync(It.IsAny<HddMetric>())).Verifiable();
            var result = _controller.Create(new HddMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.AddAsync(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
    }
}