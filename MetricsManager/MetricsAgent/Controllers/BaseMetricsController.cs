using MetricsAgent.DB.Interfaces;
using MetricsAgent.Dto;
using MetricsAgent.Entities.Metrics;
using MetricsAgent.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Базовый абстрактный контроллер
    /// </summary>
    /// <typeparam name="TMetric">Тип метрик</typeparam>
    /// <typeparam name="TDto">Используемая Dto</typeparam>
    public abstract class BaseMetricsController<TMetric, TDto> : Controller, IMetricsController<TDto>
        where TMetric : BaseMetric
        where TDto : BaseMetricDto
    {
        private readonly ILogger<BaseMetricsController<TMetric, TDto>> _logger;
        private readonly IDbRepository<TMetric> _repository;
        private readonly IMetricMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="repository">Репозиторий</param>
        /// <param name="mapper">Маппер</param>
        public BaseMetricsController(
            ILogger<BaseMetricsController<TMetric, TDto>> logger,
            IDbRepository<TMetric> repository,
            IMetricMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public virtual Task<List<TDto>> GetByTimePeriod([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation($"Подключение к контроллеру {_logger.GetType().GetGenericArguments()[0].Name}");
            _logger.LogInformation($"Получение показателей за период: с {fromTime} по {toTime}");
            return _repository.GetAll().Where(x => x.Time >= fromTime && x.Time <= toTime).Select(x => _mapper.Map<TDto>(x)).ToListAsync();
        }

        /// <inheritdoc/>
        [HttpPost("create")]
        public virtual Task Create([FromBody] TDto request)
        {
            _logger.LogInformation($"Добавление новой строки с параметрами {request.Time}, {request.Value}");
            return _repository.AddAsync(_mapper.Map<TMetric>(request)); ;
        }

        /// <inheritdoc/>
        [HttpPut("update")]
        public virtual Task Update([FromBody] TDto request)
        {
            return _repository.UpdateAsync(_mapper.Map<TMetric>(request));
        }

        /// <inheritdoc/>
        [HttpDelete("delete")]
        public virtual Task Delete([FromBody] TDto request)
        {
            return _repository.DeleteAsync(_mapper.Map<TMetric>(request));
        }
    }
}