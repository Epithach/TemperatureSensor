namespace TemperatureSensorApi.Models
{
    public class TemperatureHistory
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public double Temperature { get; set; }

        public int TemperatureStatusId { get; set; }
    }
}
