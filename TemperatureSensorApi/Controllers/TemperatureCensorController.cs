using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureCensorController : ControllerBase
    {
        public TemperatureCensorController()
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
