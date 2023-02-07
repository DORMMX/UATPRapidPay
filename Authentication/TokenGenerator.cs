using DBRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UATPRapidPay.Commands;

namespace UATPRapidPay.Authentication
{
    public static class TokenGenerator
    {
        public static string GenerateToken(AppUserLoginCommand user, string secretKey)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.NameIdentifier, user.User),                                                                
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}