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

        [HttpGet("Sensor")]
        public void GetSensor()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }
    }
}
