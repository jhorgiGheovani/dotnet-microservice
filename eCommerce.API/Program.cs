using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();

builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthorization();
app.UseAuthentication();

//Controllers routes
app.MapControllers();

app.Run();
