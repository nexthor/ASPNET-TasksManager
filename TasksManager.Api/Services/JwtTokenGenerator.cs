using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TasksManager.Api.Models;
using TasksManager.Api.Options;
using TasksManager.Api.Services.Interfaces;

namespace TasksManager.Api.Services
{
    /// <summary>
    /// Generates a JWT token for a given user.
    /// </summary>
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        public JwtTokenGenerator(IOptionsMonitor<JwtOptions> options)
            => _jwtOptions = options.CurrentValue;

        public string GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _jwtOptions.Secret ?? throw new Exception("secret must be specified to generate a new token");
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, user.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
