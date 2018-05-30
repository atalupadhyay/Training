using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public TokenController(IConfiguration config, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> RequestToken([FromBody] LoginDto user)
        {
            if (ModelState.IsValid)
            {
                var userId = await GetUserIdFromLogin(user);

                if (userId == Guid.Empty) return Unauthorized();

                // Claims erstellen (Key, Value Teile des Nutzers)
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, userId.ToString()),
                    new Claim(ClaimTypes.Role, "Teacher")
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

        private async Task<Guid> GetUserIdFromLogin(LoginDto user)
        {
            Guid userId = Guid.Empty;

            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);
            if (result.Succeeded)
            {
                var userFromDb = await _userManager.FindByEmailAsync(user.Email);
                userId = Guid.Parse(userFromDb.Id);
            }

            return userId;
        }
    }
}
