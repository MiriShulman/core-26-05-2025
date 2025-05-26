namespace OurApi.Models;

using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

public class KeyGenerator
{
    private readonly JWTSettings _jwtSettings;
    private JWTSettings jwtSettings = new JWTSettings();

    public KeyGenerator(IOptions<JWTSettings> jwtSettings) { }

    public String GenerateRandomKey(int length = 33, List<Claim> claims = null) // 33 תווים = 256 ביטים
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var secret = jwtSettings.SecretKey;
        byte[] key = Encoding.UTF8.GetBytes(secret); // המפתח הסודי שלך
        if (key== null)
        throw new ArgumentException("The psichchchch");
        
        if (key.Length == 0) // בדוק אם המפתח קצר מדי
        {
            throw new ArgumentException("The key must be at least 0 bytes long.");
        }
        if (key.Length < 16) // בדוק אם המפתח קצר מדי
        {
            throw new ArgumentException("The key must be at least 16 bytes long.");
        }
        // הגדרת המאפיינים של הטוקן
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30), // טוקן תקף ל-30 דקות
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)

        };  

    // יצירת הטוקן
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token); // מחזיר את הטוקן כמחרוזת
    }
}

