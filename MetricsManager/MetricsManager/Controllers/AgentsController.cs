using MetricsManager;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentsController : Controller
    {
        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpGet("getall/{password}")]
        public IActionResult GetAll([FromRoute] string password)
        {
            return Ok();
        }
    }
}