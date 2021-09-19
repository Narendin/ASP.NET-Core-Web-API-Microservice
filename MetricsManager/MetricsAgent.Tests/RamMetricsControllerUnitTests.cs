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
    /// Тестирование контроллера метрик оперативной памяти
    /// </summary>
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        private Mock<IDbRepository<RamMetric>> mock;
        private Mock<ILogger<RamMetricsController>> loggerMock;
        private MetricMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public RamMetricsControllerUnitTests()
        {
            mock = new Mock<IDbRepository<RamMetric>>();
            loggerMock = new Mock<ILogger<RamMetricsController>>();
            _mapper = new MetricMapper();
            _controller = new RamMetricsController(loggerMock.Object, mock.Object, _mapper);
        }

        /// <summary>
        /// Проверка метода AddAsync репозитория метрик оперативной памяти
        /// </summary>
        [Fact]
        public void Create_ShouldCall_AddAsync_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.AddAsync(It.IsAny<RamMetric>())).Verifiable();
            var result = _controller.Create(new RamMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.AddAsync(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}