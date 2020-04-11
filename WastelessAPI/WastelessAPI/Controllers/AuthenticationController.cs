using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WastelessAPI.Application.Logic;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private UserLogic _userLogic;
        private IConfiguration _config;

        public AuthenticationController(UserLogic userLogic, IConfiguration config)
        {
            _userLogic = userLogic;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody]User user)
        {
            User newUser = _userLogic.InsertNewUser(user);
            if (newUser == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]User user)
        {
            User validUser = _userLogic.GetValidUser(user);
            if (validUser != null)
            {
                var loginToken = GenerateJSONWebToken(user.Email);
                return Ok(new
                {
                    token = loginToken,
                    userId = validUser.Id
                });
            }

            return BadRequest();
        }

        private String GenerateJSONWebToken(String email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Email, email),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims,
                                            expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
