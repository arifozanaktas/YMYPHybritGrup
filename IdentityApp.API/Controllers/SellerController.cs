using IdentityApp.Services;
using IdentityApp.Services.Dto;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController(IAuthService authService) : CustomControllerBase
    {
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SignInWithSellerRequest request)
        {
            var result = await authService.SignInWithSeller(request);

            return CreateObjectResult(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "sellerSchema")]
        public IActionResult GetCities()
        {
            return Ok("cities");
        }
    }
}