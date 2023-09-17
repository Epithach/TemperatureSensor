using System.Reflection.Emit;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;
using TemperatureSensorApi.Repositories;

namespace TemperatureSensorApi.Managers
{
    public class TemperatureHistoryManager : ITemperatureHistoryManager
    {
        private readonly ITemperatureHistoryRepository _temperatureHistoryRepository;

        public TemperatureHistoryManager(ITemperatureHistoryRepository temperatureHistoryRepository)
        {
            _temperatureHistoryRepository = temperatureHistoryRepository;
        }

        public async Task<List<TemperatureHistory>> GetAll(int lastsNumber = 0)
        {
            return await _temperatureHistoryRepository.GetAll();
        }
    }

}