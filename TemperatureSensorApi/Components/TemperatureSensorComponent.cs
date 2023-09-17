using Microsoft.AspNetCore.Mvc;
using TemperatureSensorApi.Interfaces;

namespace TemperatureSensorApi.Components
{
    public class TemperatureSensorComponent : ViewComponent
    {
        public ITemperatureSensorManager _temperatureSensorManager { get; set; }

        public TemperatureSensorComponent(ITemperatureSensorManager temperatureSensorManager)
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
