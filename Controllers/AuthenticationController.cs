using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeknorixTest.Commands;
using TeknorixTest.Dtos;
using TeknorixTest.Queries;

namespace TeknorixTest.Controllers
{
    [ApiController]
    
    public class AuthenticationController(IConfiguration config) : Controller
    {
        private readonly IConfiguration _config = config; 
        
        [HttpGet]
        [Route("api/Authenticate/GetAPIKey")]
        public async Task<IActionResult> CreateAPIKey()
        {
            var claims = new[]
            {
              new Claim(ClaimTypes.Name, "testuser"),
            };

            var jwt = _config.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"].ToString(),
                audience: jwt["Audience"].ToString(),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwt["ExpiryInMinutes"])),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }

    }
}
