using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Interfaces
{
    public interface ITemperatureSensorManager
    {
        Task UpdateTemperature(string value);

        Task<TemperatureSensor> GetTemperatureSensor();

        Task<double> GetTemperature();

        Task<string> GetTemperatureMood();
    }
}
