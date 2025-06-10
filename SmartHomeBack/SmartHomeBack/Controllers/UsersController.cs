using Microsoft.AspNetCore.Mvc;
using SmartHomeBack.Services;

namespace SmartHomeBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<List<Models.User>> Get() =>
            _userService.Get();
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<Models.User> Get(string id)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            return user;
        }
        [HttpPost]
        public ActionResult<Models.User> Create(Models.User user)
        {
            Console.WriteLine(user);
            _userService.Create(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Models.User userIn)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            _userService.Update(id, userIn);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            _userService.Remove(id);
            return NoContent();
        }
        [HttpGet("username/{username}")]
        public ActionResult<Models.User> GetByUsername(string username)
        {
            var user = _userService.GetByUsername(username);
            if (user == null) return NotFound();
            return user;
        }
        [HttpGet("email/{email}")]
        public ActionResult<Models.User> GetByEmail(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user == null) return NotFound();
            return user;
        }
    }
}
