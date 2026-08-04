using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Roznama.Config;
using Roznama.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Roznama.Common.Helpers
{
    public class TokenHelper
    {
        private readonly JwtSettings _jwt;

        public TokenHelper(IOptions<AppSettings> options)
        {
            _jwt = options.Value.Jwt;
        }

        public string GenerateToken(string loginID, string userOID, string role)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_jwt.Key);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userOID", userOID),
                new Claim("loginID", loginID),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.TokenExpiryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateToken(LoginResponse user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userOID", user.UserOID.ToString()),
                new Claim("loginID", user.LoginID),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("fullName", user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _jwt.Issuer,
                _jwt.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.TokenExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}