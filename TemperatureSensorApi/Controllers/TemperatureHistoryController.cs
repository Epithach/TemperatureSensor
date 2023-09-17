using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemperatureSensorApi.DTOs.TemperatureHistory;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureHistoryController : ControllerBase
    {
        private readonly ITemperatureHistoryManager _temperatureHistoryManager;
        private readonly ITemperatureSensorManager _temperatureSensorManager;

        public TemperatureHistoryController(ITemperatureHistoryManager temperatureHistoryManager, ITemperatureSensorManager temperatureSensorManager)
        {
            _temperatureHistoryManager = temperatureHistoryManager;
            _temperatureSensorManager = temperatureSensorManager;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]int lastsNumber)
        {
            try
            {
                var historyResult = new List<TemperatureHistory>();
                if (lastsNumber == 0)
                    historyResult = await _temperatureHistoryManager.GetAll();
                else
                    historyResult = await _temperatureHistoryManager.GetAll(lastsNumber);
                if (historyResult != null)
                {
                    var result = new List<TemperatureHistoryGetDTO>();
                    foreach (var element in historyResult)
                    {
                        var mood = await _temperatureSensorManager.GetMoodByTemperature(element.Temperature);
                        result.Add(new TemperatureHistoryGetDTO()
                        {
                            Date = element.Date,
                            Temperature = element.Temperature,
                            Mood = mood
                        });
                    }
                    var response = JsonConvert.SerializeObject(result);
                    return Ok(response);
                }
                throw new Exception("An error occured while getting Temperature History");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}
