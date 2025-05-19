using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API_Nr7_Uzrasine.BusinessLogic
{

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetJwtToken(string username)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
        };

            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretToken));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];


            var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}

