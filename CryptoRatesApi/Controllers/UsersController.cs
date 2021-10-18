using AuthenticationPlugin;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CryptoRatesApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;
        private readonly AuthService _auth;
        public UsersController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _auth = new AuthService(_configuration);

        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _unitOfWork.Users.GetAll();
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var rate = _unitOfWork.Users.Get(id);
            if (rate == null)
                return NotFound("User with given id in not found");

            return Ok(rate);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var newUser = new User
            {
                username = user.username,
                email = user.email,
                password = SecurePasswordHasherHelper.Hash(user.password),


            };
                     

            _unitOfWork.Users.Create(newUser);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public ActionResult Put([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.Users.Update(user);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {

            // Find if rate exists before attempting to delete
            var rateObj = _unitOfWork.Users.Get(id);

            // If it exists, abort and notify failed delete reason
            if (rateObj == null)
                return NotFound("Specified user can't be deleted because it doesn't exist");

            //If exists proceed with deletion
            _unitOfWork.Users.Remove(rateObj);
            return NoContent();
        }

        // Login 
        [HttpPost("[action]")]
        [AllowAnonymous]
        public IActionResult Login(User user)
        {
            var userEmail = _unitOfWork.Users.Get(user.id);
            if (userEmail == null) return StatusCode(StatusCodes.Status404NotFound);

            var hashedPassword = userEmail.password;
            if (!SecurePasswordHasherHelper.Verify(user.password, hashedPassword)) return Unauthorized();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(ClaimTypes.Name, user.email),
               //new Claim(ClaimTypes.Role, user.role)
            };

            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                token_type = token.TokenType,
                user_Id = userEmail.id,
                user_name = userEmail.email,
                expires_in = token.ExpiresIn,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
            });
        }

    }
}
