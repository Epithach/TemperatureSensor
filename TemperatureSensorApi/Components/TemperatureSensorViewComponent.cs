using Microsoft.AspNetCore.Mvc;
using TemperatureSensorApi.Interfaces;

namespace TemperatureSensorApi.Components
{
    public class TemperatureSensorViewComponent : ViewComponent
    {
        public ITemperatureSensorManager _temperatureSensorManager { get; set; }

        public TemperatureSensorViewComponent(ITemperatureSensorManager temperatureSensorManager)
        {
            _temperatureSensorManager = temperatureSensorManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var temperatureSensor = await _temperatureSensorManager.GetTemperatureSensor();
            return View(temperatureSensor);
        }
    }
}
