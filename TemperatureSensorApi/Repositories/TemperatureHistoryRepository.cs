using Microsoft.EntityFrameworkCore.Migrations;
using TemperatureSensorApi.Data;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Repositories
{
    public class TemperatureHistoryRepository : ITemperatureHistoryRepository
    {
        private readonly DataContext _dataContext;

        public TemperatureHistoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TemperatureHistory>> GetAll(int lastsNumber = 0)
        {
            try
            {
                var history = _dataContext.HistoryList.OrderByDescending(x => x.Date).ToList();
                if (lastsNumber != 0)
                {
                    return history.Take(lastsNumber).ToList();
                }
                return history; 
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task Add(TemperatureHistory historyData)
        {
            try
            {
                _dataContext.HistoryList.Add(historyData);
                await _dataContext.SaveChangesAsync();
                return;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
