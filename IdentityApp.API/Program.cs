using IdentityApp.API.Extensions;
using IdentityApp.API.Requirements;
using IdentityApp.Caching;
using IdentityApp.Repositories;
using IdentityApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
        options => { options.MigrationsAssembly("IdentityApp.Repositories"); });
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthorizationHandler, ExchangeRequirementHandler>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddIdentityExt(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // kimlik doğrulama => 401
app.UseAuthorization(); // kimlik yetkilendirme => 403

app.MapControllers();

app.Run();