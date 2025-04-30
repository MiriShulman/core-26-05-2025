// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.Extensions.Hosting;

// namespace OurApi.Services
// {
//     public static class TokenService
//     {
//         private static SymmetricSecurityKey key = new SymmetricSecurityKey(
//             Encoding.UTF8.GetBytes("NJMKJHYyhgtfrdYUYHGgfd")
//         );

//         private static string issuer= "https://firstProj.com";

//         private static SecurityToken GetToken(List<Claim> claims) {
//             return new JwtSecurityToken(
//                             issuer,
//                             issuer,
//                             claims,
//                             expires: DateTime.Now.AddDays(30.0),
//                             signingCredentials: new SigningCredentials({key, SecurityAlgorithms.HmacSha256});
//                         );
//         }
                            
//         public static TokenValidationParameters GetTokenValidationParameters() =>
//             new TokenValidationParameters {
//                 ValidIssuer = issuer,
//                 ValidAudience = issuer,
//                 IssuerSigningKey = key,
//                 ClockSkew = TimeSpan.Zero
//             };

//         public static string WriteToken(SecurityToken token) =>
//             new JwtSecurityTokenHandler().WriteToken(token);

//     };
// }

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;

namespace OurApi.Services
{
    public class TokenService
    {

        private static SymmetricSecurityKey key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("NJMKJHYyhgtfrdYUYHGgfd")
        );

        private static string issuer = "https://firstProj.com";

        public static SecurityToken GetToken(List<Claim> claims) 
        {
            return new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
        }
                            
        public static TokenValidationParameters GetTokenValidationParameters() =>
            new TokenValidationParameters 
            {
                ValidIssuer = issuer,
                ValidAudience = issuer,
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero
            };

        public static string WriteToken(SecurityToken token) =>
            new JwtSecurityTokenHandler().WriteToken(token);
    }
}
