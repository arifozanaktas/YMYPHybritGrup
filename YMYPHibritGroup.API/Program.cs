using YMYPHibrit3Group.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddServiceAndRepositoryAndFilterExt();
builder.Services.AddMvcExt();
builder.Services.AddSwaggerExt();
builder.Services.AddValidationExt();

var app = builder.Build();

app.AddCommonMiddleware();

app.MapControllers();


app.Run();