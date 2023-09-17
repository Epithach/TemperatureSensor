using System.Reflection.Emit;
using System.Threading.Channels;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;
using TemperatureSensorApi.Repositories;

namespace TemperatureSensorApi.Managers
{
    public class TemperatureStatusManager : ITemperatureStatusManager
    {
        private readonly ITemperatureStatusRepository _temperatureStatusRepository;

        public TemperatureStatusManager(ITemperatureStatusRepository temperatureStatusRepository)
        {
            _temperatureStatusRepository = temperatureStatusRepository;
        }

        public async Task<string> Add(string label, string statusValue)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException(nameof(label));
            }
            if (string.IsNullOrEmpty(statusValue))
            {
                throw new ArgumentNullException(nameof(statusValue));
            }
            await _temperatureStatusRepository.Add(label, statusValue);
            return "Temperature Successfully added";
        }

        public async Task<string> Update(string label, string statusValue)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException(nameof(label));
            }
            if (string.IsNullOrEmpty(statusValue))
            {
                throw new ArgumentNullException(nameof(statusValue));
            }
            await _temperatureStatusRepository.Update(label, statusValue);
            return "Temperature Successfully updated";
        }

        public async Task<string> UpdateColdValue(string statusValue)
        {
            if (string.IsNullOrEmpty(statusValue))
            {
                throw new ArgumentNullException(nameof(statusValue));
            }
            if (double.TryParse(statusValue, out double temperature))
            {
                return await Update("COLD", temperature.ToString());
            }
            throw new ArgumentException("Temperature value is not valid");
        }

        public async Task<string> UpdateHotValue(string statusValue)
        {
            if (string.IsNullOrEmpty(statusValue))
            {
                throw new ArgumentNullException(nameof(statusValue));
            }
            if (double.TryParse(statusValue, out double temperature))
            {
                return await Update("HOT", temperature.ToString());
            }
            throw new ArgumentException("Temperature value is not valid");
        }

        public async Task<string> UpdateWarmValue(string lowValue, string highValue)
        {
            if (string.IsNullOrEmpty(lowValue))
            {
                throw new ArgumentNullException(nameof(lowValue));
            }
            if (string.IsNullOrEmpty(highValue))
            {
                throw new ArgumentNullException(nameof(highValue));
            }
            if (!double.TryParse(lowValue, out double lowtemperature))
            {
                throw new ArgumentException("Temperature low value is not valid");
            }
            if (!double.TryParse(highValue, out double hightemperature))
            {
                throw new ArgumentException("Temperature high value is not valid");
            }
            return await Update("WARM", $"{lowtemperature};{hightemperature}");
        }

        public async Task<double> GetColdTemperature()
        {
            var temperature = await GetByLabel("COLD");
            if (temperature == null)
            {
                throw new NullReferenceException(nameof(temperature));
            }
            if (double.TryParse(temperature.FirstOrDefault().StatusValue, out double t))
            {
                return t;
            }
            throw new ArgumentException("Cannot get cold temperature from value in db");
        }

        public async Task<double> GetHotTemperature()
        {
            var temperature = await GetByLabel("HOT");
            if (temperature == null)
            {
                throw new NullReferenceException(nameof(temperature));
            }
            if (double.TryParse(temperature.FirstOrDefault().StatusValue, out double t))
            {
                return t;
            }
            throw new ArgumentException("Cannot get HOT temperature from value in db");
        }

        public async Task<double> GetWarmTemperatureLimit(bool getLowLimit = true)
        {
            var temperature = await GetByLabel("WARM");
            if (temperature == null)
            {
                throw new NullReferenceException(nameof(temperature));
            }
            string[] values = temperature.FirstOrDefault().StatusValue.Split(';');
            if (values.Length != 2)
            {

                if (double.TryParse(values[getLowLimit == true ? 0 : 1], out double t))
                {
                    return t;
                }
            }
            throw new ArgumentException("Cannot get WARM temperature limits from value in db");
        }

        public async Task<List<TemperatureStatus>> GetAll()
        {
            return await _temperatureStatusRepository.GetAll();
        }

        public async Task<List<TemperatureStatus>> GetByLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException(nameof(label));
            }
            return await _temperatureStatusRepository.GetByLabel(label.ToLower());
        }
    }

}