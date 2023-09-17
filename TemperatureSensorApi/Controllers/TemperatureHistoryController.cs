using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureHistoryController : ControllerBase
    {
        private readonly ITemperatureHistoryManager _temperatureHistoryManager;

        public TemperatureHistoryController(ITemperatureHistoryManager temperatureHistoryManager)
        {
            _temperatureHistoryManager = temperatureHistoryManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery]int lastsNumber)
        {
            try
            {
                var result = new List<TemperatureHistory>();
                if (lastsNumber == 0)
                {
                    result = await _temperatureHistoryManager.GetAll();
                }
                else
                {
                    result = await _temperatureHistoryManager.GetAll(lastsNumber);
                }
                if (result != null)
                {
                    return Ok(result);
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
