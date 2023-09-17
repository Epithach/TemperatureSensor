using System.Reflection.Emit;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;
using TemperatureSensorApi.Repositories;

namespace TemperatureSensorApi.Managers
{
    public class TemperatureHistoryManager : ITemperatureHistoryManager
    {
        private readonly ITemperatureHistoryRepository _temperatureHistoryRepository;
        private readonly ITemperatureSensorManager _temperatureSensorManager;
        private readonly ITemperatureStatusManager _temperatureStatusManager;

        public TemperatureHistoryManager(ITemperatureHistoryRepository temperatureHistoryRepository, ITemperatureSensorManager temperatureSensorManager,
                ITemperatureStatusManager temperatureStatusManager)
        {
            _temperatureHistoryRepository = temperatureHistoryRepository;
            _temperatureSensorManager = temperatureSensorManager;
            _temperatureStatusManager = temperatureStatusManager;
        }

        public async Task<List<TemperatureHistory>> GetAll(int lastsNumber = 0)
        {
            return await _temperatureHistoryRepository.GetAll();
        }

        public async Task AddCurrentTemperatureData()
        {
            var currentTemperature = await _temperatureSensorManager.GetTemperature();
            var currentMood = await _temperatureSensorManager.GetTemperatureMood();
            var temperatureStatusId = await _temperatureStatusManager.GetByLabel(currentMood);
            var newHistoryData = new TemperatureHistory()
            {
                Date = DateTime.Now,
                Temperature = currentTemperature,
                TemperatureStatusId = temperatureStatusId.FirstOrDefault().ID
            };
            _temperatureHistoryRepository.Add(newHistoryData);
            return ;
        }
    }

}