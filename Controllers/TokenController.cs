using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController : ControllerBase
{
    // [HttpGet("protected-resource")]
    // public IActionResult GetProtectedResource()
    // {
    //     if (Request.Cookies.TryGetValue("JWT", out var token))
    //     {
    //         Console.WriteLine(token);
    //         var currentUserService = new CurrentUserService();
    //         var isAdmin = currentUserService.IsUserAdmin(token);
    //         Console.WriteLine(isAdmin);
    //         return Ok(new { IsAdmin = isAdmin });
    //     }

    //     return Unauthorized("Token Not Found");
    // }

    [HttpGet("protected-resource")]
    public IActionResult GetProtectedResource()
    {
        if (Request.Headers.TryGetValue("Authorization", out var headerValue))
        {
            var token = headerValue.ToString().Replace("Bearer ", "");

            Console.WriteLine(token);
            var currentUserService = new CurrentUserService();
            var isAdmin = currentUserService.IsUserAdmin(token);
            Console.WriteLine(isAdmin);
            return Ok(new { IsAdmin = isAdmin });
        }

        return Unauthorized("Token Not Found");
    }
}