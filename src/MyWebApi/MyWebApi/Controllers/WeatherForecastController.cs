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
            var _helloworld = "Hello World from InfoController!!!";
            var message = "Hello World from InfoController. This is a sample message.";
            _logger.LogInformation(message);
            return Ok(message);
        }
    }
}
