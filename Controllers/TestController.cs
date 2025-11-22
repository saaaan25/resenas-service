using Microsoft.AspNetCore.Mvc;

namespace reseñas.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok(new {
                message = "CI/CD funcionando correctamente 🎉",
                time = DateTime.UtcNow
            });
        }
    }
}