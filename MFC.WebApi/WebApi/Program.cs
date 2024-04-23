using Infrastructure;
using WebApi;

// const string endpoint = "127.0.0.1:9000";
// const string accessKey = "QQXfWpsFkknNoaIcxeOl";
// const string secretKey = "xtOIW0Yxd8qVanlzeKhZFCGQdRtCOCMrB1YVpatw";
const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddMinio(configureClient => configureClient
//     .WithEndpoint(endpoint)
//     .WithCredentials(accessKey, secretKey)
//     .WithSSL(false)
//     .Build());

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("https://localhost:7149", "http://localhost:8080", "https://localhost:3000", "http://localhost:3000") 
                .AllowAnyHeader()  
                .AllowAnyMethod();
        });
});  

builder.Services.AddInfrastructure();
builder.Services.AddWebServices();

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// TODO загрузить все файлы из папки statements в бд, если их там нет.

if (app.Environment.IsDevelopment())
{
    app.AddSwagger();
}


app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
