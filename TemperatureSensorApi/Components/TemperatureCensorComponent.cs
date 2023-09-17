using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensorApi.Components
{
    public class TemperatureCensorComponent : ViewComponent
    {
        public TemperatureCensorComponent()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
