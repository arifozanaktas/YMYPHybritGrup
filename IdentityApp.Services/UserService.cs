using IdentityApp.Repositories;
using IdentityApp.Services.Dto;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Net;
using System.Security.Claims;

namespace IdentityApp.Services
{
    public class UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : IUserService
    {
        public async Task<ServiceResult<Guid>> CreateUserAsync(CreateUserRequest request)
        {
            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                City = request.City,
                PhoneNumber = request.Phone,
                BirthDate = request.BirthDate
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return ServiceResult<Guid>.Failure(errors);


                //var errorAsString = new List<string>();
                //foreach (var identityResult in result.Errors)
                //{
                //    errorAsString.Add(identityResult.Description);

                //}
            }


            if (!string.IsNullOrEmpty(request.City))
            {
                await userManager.AddClaimAsync(user, new Claim("city", request.City));
            }

            if (request.BirthDate.HasValue)
            {
                await userManager.AddClaimAsync(user,
                    new Claim("birth_date", request.BirthDate.Value.ToString(CultureInfo.InvariantCulture)));
            }


            return ServiceResult<Guid>.Success(user.Id, HttpStatusCode.OK);
        }

        public async Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());


            if (user is null)
            {
                return ServiceResult.Failure("User not found", HttpStatusCode.NotFound);
            }

            user.Email = request.Email;
            user.UserName = request.UserName;
            user.City = request.City;
            user.PhoneNumber = request.Phone;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return ServiceResult.Failure(errors);
            }

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteUserAsync(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            if (user is null)
            {
                return ServiceResult.Failure("User not found", HttpStatusCode.NotFound);
            }

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return ServiceResult.Failure(errors);
            }

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }


        public async Task<ServiceResult> AddRoleToUserAsync(AddRoleToUserRequest request)
        {
            var hasRole = await roleManager.RoleExistsAsync(request.RoleName);


            if (!hasRole)
            {
                var role = new AppRole() { Name = request.RoleName.ToLower() };

                var result = await roleManager.CreateAsync(role);


                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    return ServiceResult.Failure(errors);
                }
            }


            var hasUser = await userManager.FindByIdAsync(request.UserId.ToString());

            if (hasUser is null)
            {
                return ServiceResult.Failure("User not found", HttpStatusCode.NotFound);
            }

            var roleToUserResult = await userManager.AddToRoleAsync(hasUser, request.RoleName);

            if (!roleToUserResult.Succeeded)
            {
                var errors = roleToUserResult.Errors.Select(e => e.Description).ToList();
                return ServiceResult.Failure(errors);
            }


            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}