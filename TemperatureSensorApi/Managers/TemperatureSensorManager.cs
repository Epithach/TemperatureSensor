using System.Reflection.Emit;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;
using TemperatureSensorApi.Repositories;

namespace TemperatureSensorApi.Managers
{
    public class TemperatureSensorManager : ITemperatureSensorManager
    {
        private readonly ITemperatureSensorRepository _temperatureSensorRepository;
        private readonly ITemperatureStatusManager _temperatureStatusManager;

        public TemperatureSensorManager(ITemperatureSensorRepository temperatureSensorRepository, ITemperatureStatusManager temperatureStatusManager)
        {
            _temperatureSensorRepository = temperatureSensorRepository;
            _temperatureStatusManager = temperatureStatusManager;
        }

        public async Task<string> GetTemperatureMood()
        {
            var mood = "NORMAL";
            var currentTemperature = await GetTemperature();
            var coldTemperature = await _temperatureStatusManager.GetColdTemperature();
            var hotTemperature = await _temperatureStatusManager.GetHotTemperature();
            var warmLowTemperatureLimit = await _temperatureStatusManager.GetWarmTemperatureLimit(true);
            var warmHighTemperatureLimit = await _temperatureStatusManager.GetWarmTemperatureLimit(false);

            if (currentTemperature >= hotTemperature)
                mood = "HOT";
            else if (currentTemperature < coldTemperature)
                mood = "COLD";
            else if (currentTemperature >= warmLowTemperatureLimit && currentTemperature < warmHighTemperatureLimit)
                mood = "WARM";
            return mood;
        }

        public async Task UpdateTemperature(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (double.TryParse(value, out double temperature))
            {
                await _temperatureSensorRepository.Update(temperature.ToString());
                return;
            }
            throw new ArgumentException("Temperature value is not valid");
        }

        public async Task<TemperatureSensor> GetTemperatureSensor()
        {
            var temperatureSensor = await _temperatureSensorRepository.Get();
            return temperatureSensor;
        }

        public async Task<double> GetTemperature()
        {
            var temperatureSensor = await _temperatureSensorRepository.Get();
            if (temperatureSensor == null)
            {
                throw new NullReferenceException(nameof(temperatureSensor));
            }
            if (double.TryParse(temperatureSensor.Temperature, out var temperature))
            { 
                return temperature;
            }
            throw new ArgumentException($"Cannot convert temperature value [{temperatureSensor.Temperature}] to double");
        }

        public async Task<string> GetMoodByTemperature(double currentTemperature)
        {
            var mood = "NORMAL";
            var coldTemperature = await _temperatureStatusManager.GetColdTemperature();
            var hotTemperature = await _temperatureStatusManager.GetHotTemperature();
            var warmLowTemperatureLimit = await _temperatureStatusManager.GetWarmTemperatureLimit(true);
            var warmHighTemperatureLimit = await _temperatureStatusManager.GetWarmTemperatureLimit(false);

            if (currentTemperature >= hotTemperature)
                mood = "HOT";
            else if (currentTemperature < coldTemperature)
                mood = "COLD";
            else if (currentTemperature >= warmLowTemperatureLimit && currentTemperature < warmHighTemperatureLimit)
                mood = "WARM";
            return mood;
        }
    }
}