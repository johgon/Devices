using Device.Domain.Models;
using DeviceServices;
using DeviceServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Device.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _service;

        public DeviceController(DeviceService service)
        {
            _service = service;
        }

        [HttpGet("getDeviceById/{id}")]
        public IActionResult GetDeviceById(int id)
        {
            var device = _service.GetById(id);
            if (device == null)
                return NotFound();
            return Ok(device);
        }

        [HttpGet("getDevicesByState/{state}")]
        public IActionResult GetDevicesByState(int state)
        {
            var device = _service.GetByState(state);
            if (device == null)
                return NotFound();
            return Ok(device);
        }

        [HttpGet("getDevicesByBrand/{brand}")]
        public IActionResult GetDevicesByBrand(string brand)
        {
            var device = _service.GetByBrand(brand);
            if (device == null)
                return NotFound();
            return Ok(device);
        }
        [HttpGet("getAllDevices/")]
        public IActionResult GetAllDevices()
        {
            var device = _service.GetAll();
            if (device == null)
                return NotFound();
            return Ok(device);
        }
        [HttpPost("CreateDevice")]
        public IActionResult CreateDevice(DeviceBO device)
        {
            var created = _service.AddOrUpdate(device, null);
            return CreatedAtAction(nameof(GetDeviceById), new { id = created.Id }, created);
        }

        [HttpPut("UpdateDevice/{id}")]
        public IActionResult AlterarProduto(DeviceBO device, int id)
        {
            _service.AddOrUpdate(device, id);
            return NoContent();
        }
        
        [HttpDelete("DeleteDevice/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDevice(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
