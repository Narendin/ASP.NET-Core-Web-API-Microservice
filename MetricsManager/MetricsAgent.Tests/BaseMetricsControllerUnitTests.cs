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
    public abstract class BaseMetricsControllerUnitTests<TController, TMetric, TDto>
        where TController : BaseMetricsController<TMetric, TDto>
        where TMetric : BaseMetric
        where TDto : BaseMetricDto, new()
    {
        private TController _controller;
        private Mock<IDbRepository<TMetric>> mock;
        private Mock<ILogger<TController>> loggerMock;
        private MetricMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        public BaseMetricsControllerUnitTests()
        {
            mock = new Mock<IDbRepository<TMetric>>();
            loggerMock = new Mock<ILogger<TController>>();
            _mapper = new MetricMapper();
            _controller = Activator.CreateInstance(typeof(TController), loggerMock.Object, mock.Object, _mapper) as TController;
        }

        /// <summary>
        /// Проверка метода AddAsync репозитория метрик процессора
        /// </summary>
        [Fact]
        public void AddAsync_ShouldCall_AddAsync_From_Repository()
        {
            var rnd = new Random();
            mock.Setup(repository => repository.AddAsync(It.IsAny<TMetric>())).Verifiable();
            var result = _controller.Create(new TDto { Time = DateTime.Now, Value = rnd.Next(50) });
            mock.Verify(repository => repository.AddAsync(It.IsAny<TMetric>()), Times.AtMostOnce());
        }
    }
}