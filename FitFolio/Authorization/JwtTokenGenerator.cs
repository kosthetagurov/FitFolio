 using FitFolio.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
 
namespace FitFolio.Authorization
{
    public class JwtTokenGenerator
    {
        private readonly string jwtSecurityKey;
        private readonly UserManager<ApplicationUser> _userManager;

        public JwtTokenGenerator(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            jwtSecurityKey = configuration["JwtSecurityKey"];
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecurityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("username", user.UserName),
                new Claim("UserPublicData", user.GetUserPublicDataJson())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = new JwtSecurityToken(
                issuer: AppDomain.CurrentDomain.FriendlyName,
                audience: "React APP",
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(5)),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
