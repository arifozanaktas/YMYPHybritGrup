namespace IdentityApp.Services.Dto
{
    public record SignInWithClientCredentialRequest(string ClientId, string ClientSecret);
}