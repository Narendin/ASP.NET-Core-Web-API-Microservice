using MetricsAgent.DB;
using MetricsAgent.Interfaces;
using MetricsManager.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsAgent.Controllers
{
    /// <summary>
    /// Базовый абстрактный контроллер
    /// </summary>
    /// <typeparam name="TRepo">Репозиторий</typeparam>
    /// <typeparam name="TMetric">Тип метрик</typeparam>
    public abstract class BaseMetricsController<TRepo, TMetric, TDto> : Controller, IMetricsController<TDto>
        where TRepo : IRepository<TMetric>
        where TMetric : class, IMetric, new()
        where TDto : IMetricDto
    {
        private readonly ILogger<BaseMetricsController<TRepo, TMetric, TDto>> _logger;
        private readonly TRepo _repository;
        private readonly Table _tableName;

        public BaseMetricsController(ILogger<BaseMetricsController<TRepo, TMetric, TDto>> logger, TRepo repository, Table tableName)
        {
            _logger = logger;
            _repository = repository;
            _tableName = tableName;
        }

        /// <summary>
        /// Получение выдержки из БД за указанный период
        /// </summary>
        /// <param name="fromTime">Начало периода</param>
        /// <param name="toTime">Конец периода</param>
        /// <returns>Найденные результаты и флаг выполнения</returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public virtual IActionResult GetByTimePeriod([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            _logger.LogInformation($"Подключение к контроллеру {_logger.GetType().GetGenericArguments()[0].Name}");
            _logger.LogInformation($"Получение показателей за период: с {fromTime} по {toTime}");
            _repository.TableName = _tableName;
            var result = _repository.GetByTimePeriod(fromTime, toTime);
            if (result is null)
            {
                _logger.LogInformation("Ничего не найдено");
                return NotFound();
            }
            _logger.LogInformation("Запрос выполнен успешно");
            return Ok(result);
        }

        [HttpPost("create")]
        public virtual IActionResult Create([FromBody] TDto request)
        {
            _logger.LogInformation($"Добавление новой строки с параметрами {request.Time}, {request.Value}");
            _repository.Create(new TMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpPut("update/time/{time}/lastValue/{lastValue}/newValue/{newValue}")]
        public virtual IActionResult Update([FromRoute] DateTime time, [FromRoute] int lastValue, [FromRoute] int newValue)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("delete/time/{time}/value/{value}")]
        public virtual IActionResult Delete([FromRoute] DateTime time, [FromRoute] int value)
        {
            throw new NotImplementedException();
        }
    }
}