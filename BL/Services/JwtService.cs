using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BL.Auxilary;
using BL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace BL.Services
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<AuthSettings> _options;

        public JwtService(IOptions<AuthSettings> options)
        {
            _options = options;
        }

      public string GenerateToken(UserLogin account)
      {
            // создаём список клеймов
            var claims = new List<Claim>
            {
            new Claim("userName", account.Login),
            new Claim("userEmail", account.Email),
            new Claim("userId", account.UserId.ToString())
            };
            // создаём Jwt Token
            var jwtToken = new JwtSecurityToken(
            expires: DateTime.UtcNow.Add(_options.Value.Expires),
            claims: claims,
            signingCredentials: new SigningCredentials(
            new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.Value.SecretKey)),
            SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
      }
   }
}
