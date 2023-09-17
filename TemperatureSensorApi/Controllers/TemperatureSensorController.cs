using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureSensorController : ControllerBase
    {
        public TemperatureSensorController()
        {

        }

        [HttpGet("status")]
        public void GetStatus()
        {
            try
            {

            }
            catch (Exception exception)
            {

            }
        }
    }
}
