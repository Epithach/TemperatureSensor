using Microsoft.AspNetCore.Mvc;
using TemperatureSensorApi.DTOs.TemperatureStatus;
using TemperatureSensorApi.Interfaces;
using TemperatureSensorApi.Models;

namespace TemperatureSensorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureStatusController : ControllerBase
    {
        private readonly ITemperatureStatusManager _temperatureStatusManager;
        public TemperatureStatusController(ITemperatureStatusManager temperatureStatusManager)
        {
            _temperatureStatusManager = temperatureStatusManager;
        }

        [HttpPut]
        public async Task<ActionResult> Update(TemperatureStatusUpdateDTO dto)
        {
            try
            {
                if (dto == null) { throw new ArgumentNullException(nameof(dto)); }

                var result = await _temperatureStatusManager.Update(dto.label, dto.value);

                if (result != null)
                {
                    return Ok(result);
                }
                throw new Exception("An error occured while updating Temperature Status");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut("cold")]
        public async Task<ActionResult> UpdateColdTemperature([FromBody] string value)
        {
            try
            {

                var result = await _temperatureStatusManager.UpdateColdValue(value);

                if (result != null)
                {
                    return Ok(result);
                }
                throw new Exception("An error occured while updating COLD Temperature");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut("hot")]
        public async Task<ActionResult> UpdateHotTemperature([FromBody] string value)
        {
            try
            {

                var result = await _temperatureStatusManager.UpdateHotValue(value);

                if (result != null)
                {
                    return Ok(result);
                }
                throw new Exception("An error occured while updating Hot Temperature");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut("warm")]
        public async Task<ActionResult> UpdateWarmTemperature(TemperatureStatusUpdateWarmTemperatureDTO dto)
        {
            try
            {
                var result = await _temperatureStatusManager.UpdateWarmValue(dto.lowValue, dto.highValue);

                if (result != null)
                {
                    return Ok(result);
                }
                throw new Exception("An error occured while updating Warm Temperature");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _temperatureStatusManager.GetAll();
                if (result != null)
                {
                    return Ok(result);
                }
                throw new Exception("An error occured while getting Temperature Status");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpGet("label/{label}")]
        public async Task<ActionResult> GetByLabel([FromRoute]string label)
        {
            try
            {
                var result = await _temperatureStatusManager.GetByLabel(label);
                if (result != null)
                {
                    return Ok(result);
                }
                throw new Exception("An error occured while getting Temperature Status");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}
