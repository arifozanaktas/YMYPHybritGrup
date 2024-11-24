using System.Text;

namespace IdentityApp.Services.Dto
{
    public record SignInWithSellerRequest(string SellerCode, string Password);
}