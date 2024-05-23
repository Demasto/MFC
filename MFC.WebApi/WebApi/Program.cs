using Infrastructure;
using Microsoft.Extensions.FileProviders;
using WebApi;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();

builder.Services.AddWebServices();
builder.Services.AddWebConfigurations();

// // добавление кэширования
// builder.Services.AddStackExchangeRedisCache(options => {
//     options.Configuration = builder.Configuration.GetConnectionString("Redis");;
//     options.InstanceName = "local";
// });

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


app.AddSwagger();

app.UseHttpsRedirection();

app.UseStaticFiles();
// app.UseStaticFiles(new StaticFileOptions()
// {
//     FileProvider = new PhysicalFileProvider(
//         Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
//     RequestPath = "/static"
// });
app.UseCors(WebApiDI.PolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
