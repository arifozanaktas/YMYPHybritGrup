using System.Text;
using IdentityApp.API.Requirements;
using IdentityApp.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace IdentityApp.API.Extensions
{
    public static class IdentityServiceExt
    {
        public static void AddIdentityExt(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddIdentity<AppUser, AppRole>(x =>
                {
                    x.Password.RequireDigit = true;
                    x.Password.RequireLowercase = false;
                    x.Password.RequireUppercase = true;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequiredLength = 6;


                    x.User.RequireUniqueEmail = true;
                    x.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                })
                .AddEntityFrameworkStores<AppDbContext>();


            service.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetSection("Symmetric")["Issuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration.GetSection("Symmetric")["Key"]!)),
                        ValidateLifetime = true,
                        ValidateAudience = false,
                    };
                }).AddJwtBearer("ClientCredentialSchema", x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetSection("Symmetric")["Issuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration.GetSection("Symmetric")["ClientCredentialKey"]!)),
                        ValidateLifetime = true,
                        ValidateAudience = false,
                    };
                }).AddJwtBearer("sellerSchema", x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetSection("Symmetric")["Issuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration.GetSection("Symmetric")["SellerKey"]!)),
                        ValidateLifetime = true,
                        ValidateAudience = false,
                    };
                });


            service.AddAuthorization(x =>
            {
                x.AddPolicy("IstanbulCityPolicy", y => { y.RequireClaim("city", "istanbul"); });


                x.AddPolicy("ExchangePolicyOver18",
                    z => { z.AddRequirements(new ExchangeRequirement() { ThresholdAge = 18 }); });
            });
        }
    }
}