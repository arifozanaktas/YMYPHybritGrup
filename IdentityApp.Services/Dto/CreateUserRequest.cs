namespace IdentityApp.Services.Dto;

public record CreateUserRequest(
    string UserName,
    string Email,
    string Password,
    string? City,
    string? Phone,
    DateTime? BirthDate);