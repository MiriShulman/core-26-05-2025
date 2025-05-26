using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using OurApi.Models;

namespace OurApi.Services;

public class LoginService
{

    private readonly string _secretKey;
    private readonly JWTSettings _jwtSettings;

    public LoginService(IOptions<JWTSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings));

        // בדוק אם jwtSettings לא ריק ואם המפתח קיים
        if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Value.SecretKey))
        {
            throw new ArgumentException("JWT settings must be provided and the SecretKey must not be empty.");
        }

    }

    public string GenerateToken(List<Claim> claims)
    {

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "yourIssuer",
            audience: "yourAudience",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

