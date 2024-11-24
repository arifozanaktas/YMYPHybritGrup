using IdentityApp.Services.Dto;

namespace IdentityApp.Services;

public interface IUserService
{
    Task<ServiceResult<Guid>> CreateUserAsync(CreateUserRequest request);
    Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request);
    Task<ServiceResult> DeleteUserAsync(Guid id);
    Task<ServiceResult> AddRoleToUserAsync(AddRoleToUserRequest request);
}