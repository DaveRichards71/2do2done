using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace IdentityApi;

public class TokenGenerator
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expirationInMinutes = 60;
    private readonly SymmetricSecurityKey _securityKey;

    public TokenGenerator(IConfiguration configuration)
    {        
        _issuer = configuration["Jwt:Issuer"]
                  ?? throw new InvalidOperationException("Jwt:Issuer is not set in configuration.");
        _audience = configuration["Jwt:Audience"]
                    ?? throw new InvalidOperationException("Jwt:Audience is not set in configuration.");
        var keyString = configuration["Jwt:Secret"]
                        ?? throw new InvalidOperationException("Jwt:Secret is not set in configuration.");
        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        _expirationInMinutes = configuration.GetValue<int>("Jwt:ExpirationInMinutes");        
    }
    public string GenerateToken(string email)
    {
        var tokenHandler = new JsonWebTokenHandler();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.Email, email),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_expirationInMinutes),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token;
    }
}
