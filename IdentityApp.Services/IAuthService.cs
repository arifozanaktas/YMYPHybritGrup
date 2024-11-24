using IdentityApp.Services.Dto;

namespace IdentityApp.Services;

public interface IAuthService
{
    Task<ServiceResult<TokenResponse>> SignInAsync(SignInRequest request);

    Task<ServiceResult<TokenResponse>> SignInWithClientCredential(
        SignInWithClientCredentialRequest request);

    Task<ServiceResult<TokenResponse>> SignInWithSeller(SignInWithSellerRequest request);
}