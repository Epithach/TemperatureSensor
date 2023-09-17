using Moq;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Managers;
using TemperatureSensorApi.Models;

namespace TemperatureSensorTest
{
    public class Tests
    {
        private ITemperatureSensorRepository _temperatureSensorRepository;
        private ITemperatureStatusManager _temperatureStatusManager;

        [SetUp]
        public void Setup()
        {
            var warmTemperature = new TemperatureSensor() { Temperature = "24"};

            var temperatureSensorRepositoryMoq = new Mock<ITemperatureSensorRepository>();
            temperatureSensorRepositoryMoq.Setup(x => x.Get()).ReturnsAsync(warmTemperature);
            _temperatureSensorRepository = temperatureSensorRepositoryMoq.Object;

            var temperatureStatuses = new List<TemperatureStatus>();
            temperatureStatuses.Add(new TemperatureStatus() { ID = 1, Label = "WARM", StatusValue = "22;35"});
            temperatureStatuses.Add(new TemperatureStatus() { ID = 2, Label = "COLD", StatusValue = "22" });
            temperatureStatuses.Add(new TemperatureStatus() { ID = 3, Label = "HOT", StatusValue = "35" });

            var temperatureStatusManagerMoq = new Mock<ITemperatureStatusManager>();
            temperatureStatusManagerMoq.Setup(x => x.GetAll()).ReturnsAsync(temperatureStatuses);
            _temperatureStatusManager = temperatureStatusManagerMoq.Object;
        }

        [Test]
        public void GetTemperatureSensor_Test()
        {
            //ARANGE 
            TemperatureSensorManager _manager = new TemperatureSensorManager(_temperatureSensorRepository, _temperatureStatusManager);

            //ACT
            var result = _manager.GetTemperatureSensor();

            //ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual("24", result.Result.Temperature);
        }
    }
}