using Microsoft.EntityFrameworkCore;
using TemperatureSensorApi.Data;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Managers;
using TemperatureSensorApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITemperatureStatusRepository, TemperatureStatusRepository>();
builder.Services.AddTransient<ITemperatureStatusManager, TemperatureStatusManager>();
builder.Services.AddTransient<ITemperatureHistoryRepository, TemperatureHistoryRepository>();
builder.Services.AddTransient<ITemperatureHistoryManager, TemperatureHistoryManager>();
builder.Services.AddTransient<ITemperatureHistoryRepository, TemperatureHistoryRepository>();
builder.Services.AddTransient<ITemperatureSensorManager, TemperatureSensorManager>();
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

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
