using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoGlassController : ControllerBase
    {

        private readonly ILogger<AutoGlassController> _logger;

        public AutoGlassController(ILogger<AutoGlassController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}