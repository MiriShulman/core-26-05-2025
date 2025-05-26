using Microsoft.AspNetCore.Mvc;
using OurApi.Services;
using System.Security.Claims;
using OurApi.Models;
using OurApi.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace OurApi.Controllers;

public class CurrentUserService
{
public bool IsUserAdmin(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("i-love-you_We_are_i_&_Tovi_Kuperman")), // מפתח סודי שלך
            ValidateIssuer = false,
            ValidateAudience = false
        }, out var validatedToken);

        return principal.FindFirst("type")?.Value == "Admin";
    }
}