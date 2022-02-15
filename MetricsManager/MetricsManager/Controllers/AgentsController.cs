using MetricsManager.DB;
using MetricsManager.DB.Interfaces;
using MetricsManager.Dto;
using MetricsManager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentsController : Controller
    {
        private readonly ILogger<AgentsController> _logger;
        private readonly IDbRepository<AgentInfo> _repository;
        private readonly IMetricMapper _mapper;

        public AgentsController(
            ILogger<AgentsController> logger,
            IDbRepository<AgentInfo> repository,
            IMetricMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("reg")]
        public IActionResult RegisterAgent([FromBody] AgentInfoDto agentInfo)
        {
            _repository.AddAsync(_mapper.Map<AgentInfo>(agentInfo));
            _logger.LogInformation($"Зарегистрирован агент {agentInfo.Name}.");
            return Ok();
        }

        [HttpPut("unreg")]
        public IActionResult DisableAgentById([FromBody] AgentInfoDto agentInfo)
        {
            _logger.LogInformation($"Регистрация агента {agentInfo.Name} прекращена.");
            _repository.DeleteAsync(_mapper.Map<AgentInfo>(agentInfo));
            return Ok();
        }
    }
}