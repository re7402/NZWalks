using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace NZWalks.API.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;
        private readonly ITokenRepository _tokenRepository;
        public TokenRepository(ITokenRepository tokenRepository)
        {
            this._tokenRepository = tokenRepository;
        }

        public string CreateJwtToken(IdentityUser user, List<string> Roles)
        {
            //create claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //create token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials =  new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials:credentials
                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token) ;
        }
    }
}
