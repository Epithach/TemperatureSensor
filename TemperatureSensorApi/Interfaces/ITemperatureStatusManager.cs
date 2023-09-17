using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Interfaces
{
    public interface ITemperatureStatusManager
    {
        Task<string> Add(string label, string statusValue);

        Task<string> Update(string label, string statusValue);

        Task<List<TemperatureStatus>> GetAll();

        Task<List<TemperatureStatus>> GetByLabel(string label);

        Task<string> UpdateColdValue(string statusValue);

        Task<string> UpdateHotValue(string statusValue);

        Task<string> UpdateWarmValue(string lowValue, string highValue);

        Task<double> GetWarmTemperatureLimit(bool getLowLimit = true);

        Task<double> GetHotTemperature();

        Task<double> GetColdTemperature();
    }
}
