using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NashSneaker.Helpers
{
    public class JwtService
    {
        private IConfiguration _config;

        public JwtService (IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwt(User user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims, null, DateTime.Now.AddDays(1));

            var securityToken = new JwtSecurityToken(header, payload);
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }

        //public JwtSecurityToken ValidateJwt(string jwt)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(secretKey);

        //    tokenHandler.ValidateToken(jwt, new TokenValidationParameters {
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuerSigningKey = true,
        //        ValidateAudience = false,
        //        ValidateIssuer = false
        //    }, out SecurityToken validatedToken);

        //    return (JwtSecurityToken) validatedToken;
        //}
    }
}
