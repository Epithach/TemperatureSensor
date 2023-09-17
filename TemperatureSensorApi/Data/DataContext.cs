using Microsoft.EntityFrameworkCore;
using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Data
{
    public class DataContext : DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TemperatureHistory> HistoryList => Set<TemperatureHistory>();
        public DbSet<TemperatureStatus> TemperatureStatusList => Set<TemperatureStatus>();
        public DbSet<TemperatureSensor> TemperatureSensor => Set<TemperatureSensor>();
    }
}
