using Application;
using Infraestructure;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StoreApi;
using StoreApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

#region Logger
var logger = new LoggerConfiguration()
 .ReadFrom.Configuration(builder.Configuration)
 .Enrich.FromLogContext()
 .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
#endregion

#region Services
builder.Services.ConfigureJWT(appSettings);
builder.Services.ConfigureCors(appSettings);
builder.Services.ConfigureMapper();
builder.Services.ConfigureSwagger(appSettings);
builder.Services.ConfigureIISIntegration();
builder.Services.AddServices(appSettings);
builder.Services.SetupInfrastructureLayer(builder.Configuration, appSettings.ConnectionStrings.StoreConnection);
builder.Services.SetupApplicationLayer();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
