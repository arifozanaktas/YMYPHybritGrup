using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok("create");
        }

        [Authorize(Roles = "editor")]
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok("update");
        }


        [Authorize(policy: "ExchangePolicyOver18")]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var claims = User.Claims;

            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var email = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;


            return Ok("delete");
        }
    }
}