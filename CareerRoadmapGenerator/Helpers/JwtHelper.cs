using CareerRoadmapGenerator.Models;
using CareerRoadmapGenerator.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareerRoadmapGenerator.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateToken(ApplicationUser user, IConfiguration config)
        {
            // 🔒 Null safety checks (VERY IMPORTANT)
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(user.Id))
                throw new Exception("User ID cannot be null.");

            if (string.IsNullOrEmpty(user.UserName))
                throw new Exception("Username cannot be null.");

            var jwtKey = config["Jwt:Key"];
            var issuer = config["Jwt:Issuer"];
            var audience = config["Jwt:Audience"];

            if (string.IsNullOrEmpty(jwtKey) ||
                string.IsNullOrEmpty(issuer) ||
                string.IsNullOrEmpty(audience))
            {
                throw new Exception("JWT configuration is missing in appsettings.json");
            }

            // ✅ Claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            // ✅ Signing key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // ✅ Token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
