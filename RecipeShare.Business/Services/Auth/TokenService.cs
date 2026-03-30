using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RecipeShare.Business.DTOs;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShare.Business.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(UserDTO userDTO)
        {
            // 1. Ayarları appsettings.json
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"]);

            // 2. Sifreleme anahtarı oluştur
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Token oluştur
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userDTO.Id.ToString()),
                new Claim(ClaimTypes.Name, userDTO.Username),
                new Claim(ClaimTypes.Email,userDTO.Email),
                new Claim(ClaimTypes.Role, userDTO.RoleName)
            };

            // 4. Token özellikleri
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = issuer,
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Audience = audience,
                SigningCredentials = creds
            };

            // 5. Token'ı oluşturup imzala
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
