using Microsoft.EntityFrameworkCore;

namespace TemperatureSensorApi.Models
{
    [Keyless]
    public class TemperatureSensor
    {
        public string Temperature { get; set; }
    }
}
