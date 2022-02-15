using MetricsManager.DB;
using MetricsManager.DB.Interfaces;
using MetricsManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    public abstract class BaseMetricsController<TDto> : Controller
    {
        private readonly ILogger<BaseMetricsController<TDto>> _logger;
        private readonly IDbRepository<AgentInfo> _repository;
        private readonly IMetricMapper _mapper;

        public BaseMetricsController(
            ILogger<BaseMetricsController<TDto>> logger,
            IDbRepository<AgentInfo> repository,
            IMetricMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public virtual IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            var uri = _repository.GetAll().Where(x => x.Id == agentId).Select(x => x.Adress).First();
            if (uri == null) return BadRequest();

            uri += $"/from/{fromTime}/to/{toTime}";

            return Ok();
        }
    }
}