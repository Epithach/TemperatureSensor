using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TemperatureSensorApi.Interfaces;

namespace TemperatureSensorApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TemperatureSensorController : Controller
    {
        public ITemperatureSensorManager _temperatureSensorManager { get; set; }

        public TemperatureSensorController(ITemperatureSensorManager temperatureSensorManager)
        {
            _temperatureSensorManager = temperatureSensorManager;
        }

        [HttpGet("mood")]
        public async Task<IActionResult> GetTemperatureMood()
        {
            try
            {
                var mood = await _temperatureSensorManager.GetTemperatureMood();
                return Ok(mood);
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

        [HttpGet("temperature")]
        public async Task<IActionResult> GetTemperature()
        {
            try
            {
                var mood = await _temperatureSensorManager.GetTemperature();
                return Ok(mood);
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
