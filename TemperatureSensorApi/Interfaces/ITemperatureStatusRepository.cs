using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Interfaces
{
    public interface ITemperatureStatusRepository
    {
        Task Add(string label, string statusValue);

        Task Update(string label, string statusValue);

        Task<List<TemperatureStatus>> GetAll();
        
        Task<List<TemperatureStatus>> GetByLabel(string label);
    }
}
