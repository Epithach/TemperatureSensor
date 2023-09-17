using System.Reflection.Emit;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;
using TemperatureSensorApi.Repositories;

namespace TemperatureSensorApi.Managers
{
    public class TemperatureSensorManager : ITemperatureSensorManager
    {
        private readonly ITemperatureSensorRepository _temperatureSensorRepository;

        public TemperatureSensorManager(ITemperatureSensorRepository temperatureSensorRepository)
        {
            _temperatureSensorRepository = temperatureSensorRepository;
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
    }

}