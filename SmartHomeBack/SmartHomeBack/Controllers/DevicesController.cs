using Microsoft.AspNetCore.Mvc;
using SmartHomeBack.Models;
using SmartHomeBack.Services;


namespace SmartHomeBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceService _deviceService;

        public DevicesController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public ActionResult<List<Device>> Get() =>
            _deviceService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDevice")]
        public ActionResult<Device> Get(string id)
        {
            var device = _deviceService.Get(id);
            if (device == null) return NotFound();
            return device;
        }

        [HttpPost]
        public ActionResult<Device> Create(Device device)
        {
            Console.WriteLine(device);
            _deviceService.Create(device);
            return CreatedAtRoute("GetDevice", new { id = device.Id }, device);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Device deviceIn)
        {
            var device = _deviceService.Get(id);
            if (device == null) return NotFound();

            _deviceService.Update(id, deviceIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var device = _deviceService.Get(id);
            if (device == null) return NotFound();

            _deviceService.Remove(id);
            return NoContent();
        }
    }
}
