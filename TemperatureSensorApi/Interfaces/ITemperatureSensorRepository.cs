using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Interfaces
{
    public interface ITemperatureSensorRepository
    {
        Task<TemperatureSensor> Get();

        Task Update(string temperature);
    }
}
