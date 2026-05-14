
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyStore.Service.DTOs.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyStore.Service.AuthService.cs
{
    public class AuthService(IConfiguration config) : IAuthService
    {
        private static readonly List<(string Email, string Password, string Role)> _users =
        [
            ("admin@mystore.com",    "Admin123!",    "Admin"),
            ("staff@mystore.com",    "Staff123!",    "Staff"),
            ("customer@mystore.com", "Customer123!", "Customer")
        ];


        public LoginResponseDto? Login(LoginRequestDto request)
        {
            var user = _users.FirstOrDefault(u =>
                u.Email == request.Email && u.Password == request.Password);

            if (user == default) return null;

            var expiresAt = DateTime.UtcNow.AddMinutes(60);

            return new LoginResponseDto
            {
                Token = GenerateToken(user.Email, user.Role, expiresAt),
                Email = user.Email,
                Role = user.Role,
                ExpiresAt = expiresAt
            };
        }

        private string GenerateToken(string email, string role, DateTime expiresAt)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,            email),
                new Claim(ClaimTypes.Role,             role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
