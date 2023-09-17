using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Interfaces
{
    public interface ITemperatureHistoryManager
    {
        Task<List<TemperatureHistory>> GetAll(int lastsNumber = 0);

        Task AddCurrentTemperatureData();
    }
}
