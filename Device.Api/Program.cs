using Device.Repository;
using Device.Repository.Data;
using Device.Repository.Interfaces;
using DeviceServices;
using DeviceServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Conexão com banco
builder.Services.AddDbContext<DeviceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceService, DeviceService>();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<DeviceDbContext>();

    dbContext.Database.Migrate();
}
try
{
    app.MapControllers();
}
catch (ReflectionTypeLoadException ex)
{
    Console.WriteLine(ex.Message);
    foreach (var le in ex.LoaderExceptions) Console.WriteLine(le.GetType().FullName + ": " + le.Message);
    throw;
}

app.Run();
