using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Interfaces
{
    public interface ITemperatureHistoryRepository
    {
        Task<List<TemperatureHistory>> GetAll(int lastsNumber = 0);

        Task Add(TemperatureHistory historyData);
    }
}
