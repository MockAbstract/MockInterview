using MockInterview.API.LogConfig;
using Serilog;
using UtilityApi.Logs;

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var logger = LogConfigurations.SetLogConfiguration(builder)
  //  .CreateLogger();

//builder.Logging.AddSerilog(logger);
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.ConfigureExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
