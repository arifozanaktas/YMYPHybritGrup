using IdentityApp.Services;
using IdentityApp.Services.Dto;

namespace IdentityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, IConfiguration configuration) : CustomControllerBase
    {
        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync(SignInRequest request)
        {
            var result = await authService.SignInAsync(request);

            return CreateObjectResult(result);
        }

        [HttpPost("signin-client-credential")]
        public async Task<IActionResult> SignInWithClientCredentialAsync(SignInWithClientCredentialRequest request)
        {
            var result = await authService.SignInWithClientCredential(request);

            return CreateObjectResult(result);
        }
    }
}