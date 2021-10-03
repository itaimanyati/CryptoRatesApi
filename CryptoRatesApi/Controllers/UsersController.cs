using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CryptoRatesApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUser _userRepository;

        public UsersController(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var rate = _userRepository.GetUser(id);
            if (rate == null)
                return NotFound("User with given id in not found");

            return Ok(rate);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userRepository.AddUser(user);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userRepository.UpdateUser(user);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {

            // Find if rate exists before attempting to delete
            var rateObj = _userRepository.GetUser(id);

            // If it exists, abort and notify failed delete reason
            if (rateObj == null)
                return NotFound("Specified user can't be deleted because it doesn't exist");

            //If exists proceed with deletion
            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
