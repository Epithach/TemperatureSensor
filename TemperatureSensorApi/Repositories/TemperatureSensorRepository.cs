using TemperatureSensorApi.Data;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Repositories
{
    public class TemperatureSensorRepository : ITemperatureSensorRepository
    {
        public DataContext _dataContext { get; set; }
        public TemperatureSensorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TemperatureSensor> Get()
        {
            var sensor = _dataContext.TemperatureSensor.FirstOrDefault();
            if (sensor == null)
            {
                throw new NullReferenceException("Temperature Sensor is null, it might not be initialized");
            }
            return sensor;
        }

        public async Task Update(string temperature)
        {
            try
            {
                var currentStatus = _dataContext.TemperatureSensor.FirstOrDefault();
                if (currentStatus != null)
                {
                    currentStatus.Temperature = temperature;
                    await _dataContext.SaveChangesAsync();
                    return;
                }
                throw new NullReferenceException("Temperature Sensor is null, it might not be initialized");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
