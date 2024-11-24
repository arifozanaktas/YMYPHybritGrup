using IdentityApp.Services;
using IdentityApp.Services.Dto;
using Microsoft.AspNetCore.Authorization;

namespace IdentityApp.API.Controllers
{
    public class UsersController(IUserService userService) : CustomControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var result = await userService.CreateUserAsync(request);

            return CreateObjectResult(result);
        }


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var result = await userService.UpdateUserAsync(request);

            return CreateObjectResult(result);
        }


        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await userService.DeleteUserAsync(id);

            return CreateObjectResult(result);
        }

        [AllowAnonymous]
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserRequest request)
        {
            var result = await userService.AddRoleToUserAsync(request);

            return CreateObjectResult(result);
        }
    }
}