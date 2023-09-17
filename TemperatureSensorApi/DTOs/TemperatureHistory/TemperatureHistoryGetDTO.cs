namespace TemperatureSensorApi.DTOs.TemperatureHistory
{
    public class TemperatureHistoryGetDTO
    {
        public DateTime Date { get; set; }

        public double Temperature { get; set; }

        public string Mood { get; set; }
    }
}
