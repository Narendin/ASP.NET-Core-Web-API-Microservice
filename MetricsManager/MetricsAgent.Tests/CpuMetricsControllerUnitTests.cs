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
    /// Тестирование контроллера метрик процессора
    /// </summary>
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;
        private Mock<IDbRepository<CpuMetric>> mock;
        private Mock<ILogger<CpuMetricsController>> loggerMock;
        private MetricMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<IDbRepository<CpuMetric>>();
            loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _mapper = new MetricMapper();
            _controller = new CpuMetricsController(loggerMock.Object, mock.Object, _mapper);
        }

        /// <summary>
        /// Проверка метода AddAsync репозитория метрик процессора
        /// </summary>
        [Fact]
        public void Create_ShouldCall_AddAsync_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.AddAsync(It.IsAny<CpuMetric>())).Verifiable();
            var result = _controller.Create(new CpuMetricDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.AddAsync(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}