using FdkElevator.AppDbContext;
using FdkElevator.Models.Auth;
using FdkElevator.Services.IServices;
using FdkElevator.Utility;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FdkElevator.Services
{
    public class JwtService : IJwt
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtOptions _jwtoptions;

        public JwtService(ApplicationDbContext context, IOptions<JwtOptions> options)
        {
            _context = context;
            _jwtoptions = options.Value;
        }


        public string generateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtoptions.SecretKey));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _jwtoptions.Issuer,
                Audience = _jwtoptions.Audience,
                Expires = DateTime.UtcNow.AddHours(4),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = cred
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token); throw new NotImplementedException();
        }

        }
}
