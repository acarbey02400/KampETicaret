using KampETicaret.Application.Abstractions.TokenManager;
using KampETicaret.Application.Dtos;
using KampETicaret.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Infrasturcture.Services.TokenServices
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(AppUser appUser, IList<string> roles)
        {
            //Security Key Simetriği alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //Return edeceğimiz token'ı oluşturup süresini 2 saat olarak belirliyoruz.
            Token token = new Token() { Expiration = DateTime.UtcNow.AddHours(2) };

            //Token oluştururken konfigürasyon bilgilerini giriyoruz.
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["TokenOptions:Issuer"],
                audience: _configuration["TokenOptions:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials,
                claims: setClaims(appUser, roles)
                );
            //Token oluşturma işlemini tamamlayıp return ediyoruz.
            JwtSecurityTokenHandler jwtTokenHandler = new();
            token.AccessToken = jwtTokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
        private IEnumerable<Claim> setClaims(AppUser user, IList<string> roles)
        {
            var claims = new List<Claim>();

            claims.Add(new(ClaimTypes.Name, user.FullName));
            claims.Add(new(JwtRegisteredClaimNames.Email, user.Email));
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }
            return claims;

        }

    }
}
