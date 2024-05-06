using Infrastructure;
using WebApi;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();

builder.Services.AddWebServices();
builder.Services.AddWebConfigurations();

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//    
// }

app.AddSwagger();

app.UseHttpsRedirection();

app.UseCors(WebApiDI.PolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
