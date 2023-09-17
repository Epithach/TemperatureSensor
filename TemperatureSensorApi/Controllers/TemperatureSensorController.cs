using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.ViewModels;

namespace TemperatureSensorApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TemperatureSensorController : Controller
    {
        public ITemperatureSensorManager _temperatureSensorManager { get; set; }
        public ITemperatureStatusManager _temperatureStatusManager { get; set; }

        public TemperatureSensorController(ITemperatureSensorManager temperatureSensorManager, ITemperatureStatusManager temperatureStatusManager)
        {
            _temperatureSensorManager = temperatureSensorManager;
            _temperatureStatusManager = temperatureStatusManager;
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
            var currentMood = _temperatureSensorManager.GetTemperatureMood().Result;
            var currentTemperatureStatus = _temperatureStatusManager.GetByLabel(currentMood).Result;
            var viewModel = new TemperatureSensorViewModel()
            {
                Mood = currentMood,
                TemperatureStatusId = currentTemperatureStatus.FirstOrDefault().ID
            };
            switch (viewModel.TemperatureStatusId)
            {
                case 1:
                    viewModel.Message = "SIUUUU !!! I am at my best !";
                    break;
                case 2:
                    viewModel.Message = "Brrrrr it'z cold today !";
                    break;
                case 3:
                    viewModel.Message = "Pleaaaase... Give me some water, I am burning !";
                    break;
                default:
                    viewModel.Message = "Hum, I don't know what to think.";
                    break;
            }
            return View(viewModel);
        }
    }
}
