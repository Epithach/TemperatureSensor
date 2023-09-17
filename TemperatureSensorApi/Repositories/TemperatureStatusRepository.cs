using TemperatureSensorApi.Data;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Repositories
{
    public class TemperatureStatusRepository : ITemperatureStatusRepository
    {
        private readonly DataContext _dataContext;

        public TemperatureStatusRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task Add(string label, string statusValue)
        {
            try
            {
                var newStatus = new TemperatureStatus()
                {
                    Label = label,
                    StatusValue = statusValue
                };
                _dataContext.TemperatureStatusList.Add(newStatus);
                await _dataContext.SaveChangesAsync();
                return;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task Update(string label, string statusValue)
        {
            try
            {
                var currentStatus = _dataContext.TemperatureStatusList.FirstOrDefault(x => x.Label.ToLower() == label);
                if (currentStatus != null)
                {
                    currentStatus.StatusValue = statusValue;
                    await _dataContext.SaveChangesAsync();
                    return;
                }
                throw new ArgumentException($"Status not found for label : {label}");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<List<TemperatureStatus>> GetAll()
        {
            try
            {
                return _dataContext.TemperatureStatusList.Select(x => x).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<List<TemperatureStatus>> GetByLabel(string label)
        {
            try
            {
                return _dataContext.TemperatureStatusList.Where(x => x.Label.ToLower() == label).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
