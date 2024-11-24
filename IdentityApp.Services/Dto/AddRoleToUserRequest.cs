namespace IdentityApp.Services.Dto
{
    public record AddRoleToUserRequest(Guid UserId, string RoleName);
}