using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensorApi.Components
{
    public class TemperatureCensorComponent : ViewComponent
    {
        public double Temperature { get; set; }

        public TemperatureCensorComponent(double temperature)
        {
            Temperature = temperature;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
