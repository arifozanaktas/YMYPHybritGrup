using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = "ClientCredentialSchema")]
        public IActionResult Forecast()
        {
            return Ok("forecast");
        }
    }
}