using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace auth_api.App.Jwt;

public class JwtService
{
    private readonly string _secretKey;

    public JwtService()
    {
        var key = Environment.GetEnvironmentVariable("JWT_SECRET");

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("JWT_SECRET environment variable is not set");
        }

        _secretKey = key;
    }

    public string GenerateToken(string username)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, username, ClaimValueTypes.String)
        };

        var jwt = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_secretKey)
                ),
                SecurityAlgorithms.HmacSha256Signature)
        );
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}