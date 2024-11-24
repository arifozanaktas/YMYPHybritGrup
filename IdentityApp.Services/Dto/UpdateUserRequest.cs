namespace IdentityApp.Services.Dto
{
    public record UpdateUserRequest(Guid Id, string Email, string UserName, string? City, string? Phone);
}