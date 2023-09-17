using Microsoft.AspNetCore.Mvc;
using TemperatureSensorApi.Interfaces;

namespace TemperatureSensorApi.Components
{
    public class TemperatureCensorComponent : ViewComponent
    {
        public ITemperatureSensorManager _temperatureSensorManager { get; set; }

        public TemperatureCensorComponent(ITemperatureSensorManager temperatureSensorManager)
        {
            _temperatureSensorManager = temperatureSensorManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var temperatureSensor = _temperatureSensorManager.GetTemperatureSensor();
            return View(temperatureSensor);
        }
    }
}
