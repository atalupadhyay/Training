using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using APIDemo.Dtos;

namespace APIDemo.Controllers
{
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;

        public TokenController(IConfiguration config, UserManager<IdentityUser> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult RequestToken([FromBody] LoginDto user)
        {
            //https://stackoverflow.com/questions/42036810/asp-net-core-jwt-mapping-role-claims-to-claimsidentity
            if (ModelState.IsValid)
            {
                var userId = GetUserIdFromLogin(user);

                if (userId == -1) return Unauthorized();

                // Claims erstellen (Key, Value Teile des Nutzers)
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                // Token erstellen auf Basis der Claims
                var token = new JwtSecurityToken
                    (
                        issuer: _config["Issuer"],
                        audience: _config["Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddDays(60),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(_config["SigningKey"])),
                                SecurityAlgorithms.HmacSha256)
                    );

                // Token ausgeben mittels Token Handler
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            return BadRequest();
        }

        private int GetUserIdFromLogin(LoginDto user)
        {
            var userId = -1;

            //if (user.Email.Equals("admin") && user.Password.Equals("Password1!"))
            //{
            //    userId = 1234;
            //}

            var userFromDb = _userManager.FindByEmailAsync(user.Email);
            if (userFromDb != null)
            {
                userId = userFromDb.Id;
            }

            return userId;
        }
    }
}
