using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<InfoController> _logger;

        public InfoController(ILogger<InfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public IActionResult Get()
        {
            _logger.LogInformation("Hello World from InfoController!");
            return Ok("Hello World");
        }
    }
}
