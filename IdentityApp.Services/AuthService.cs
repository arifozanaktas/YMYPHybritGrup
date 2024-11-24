using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityApp.Repositories;
using IdentityApp.Services.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityApp.Services
{
    public class AuthService(UserManager<AppUser> userManager, IConfiguration configuration, AppDbContext context)
        : IAuthService
    {
        public async Task<ServiceResult<TokenResponse>> SignInAsync(SignInRequest request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);


            if (user == null)
            {
                return ServiceResult<TokenResponse>.Failure("Email veya Şifre yanlış.");
            }

            if (!await userManager.CheckPasswordAsync(user, request.Password))
            {
                return ServiceResult<TokenResponse>.Failure("Email veya Şifre yanlış.");
            }

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };


            var userRoleList = await userManager.GetRolesAsync(user);

            foreach (var role in userRoleList)
            {
                claimList.Add(new Claim(ClaimTypes.Role, role));
            }

            var userClaims = await userManager.GetClaimsAsync(user);


            foreach (var claim in userClaims)
            {
                claimList.Add(claim);
            }


            string symmetricKey = configuration.GetSection("Symmetric")["Key"]!;
            string issuer = configuration.GetSection("Symmetric")["Issuer"]!;

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricKey)), SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimList,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials,
                issuer: issuer
            );

            var handler = new JwtSecurityTokenHandler();

            var accessToken = handler.WriteToken(token);


            return ServiceResult<TokenResponse>.Success(new TokenResponse(accessToken));
        }

        public async Task<ServiceResult<TokenResponse>> SignInWithClientCredential(
            SignInWithClientCredentialRequest request)
        {
            var webClientId = configuration.GetSection("Clients")["ClientId"];
            var webClientSecret = configuration.GetSection("Clients")["ClientSecret"];


            if (webClientId != request.ClientId || webClientSecret != request.ClientSecret)
            {
                return ServiceResult<TokenResponse>.Failure("Client bilgileri yanlış.");
            }

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, request.ClientId)
            };


            string symmetricKey = configuration.GetSection("Symmetric")["ClientCredentialKey"]!;
            string issuer = configuration.GetSection("Symmetric")["Issuer"]!;

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricKey)), SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimList,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials,
                issuer: issuer
            );

            var handler = new JwtSecurityTokenHandler();

            var accessToken = handler.WriteToken(token);


            return ServiceResult<TokenResponse>.Success(new TokenResponse(accessToken));
        }


        public async Task<ServiceResult<TokenResponse>> SignInWithSeller(SignInWithSellerRequest request)
        {
            var hasSeller = context.Sellers.Any(x => x.Code == request.SellerCode && x.Password == request.Password);


            if (!hasSeller)
            {
                return ServiceResult<TokenResponse>.Failure("Satıcı bulunamadı.");
            }

            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, request.SellerCode)
            };

            string symmetricKey = configuration.GetSection("Symmetric")["SellerKey"]!;
            string issuer = configuration.GetSection("Symmetric")["Issuer"]!;

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symmetricKey)), SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                claims: claimList,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials,
                issuer: issuer
            );

            var handler = new JwtSecurityTokenHandler();

            var accessToken = handler.WriteToken(token);


            return ServiceResult<TokenResponse>.Success(new TokenResponse(accessToken));
        }
    }
}