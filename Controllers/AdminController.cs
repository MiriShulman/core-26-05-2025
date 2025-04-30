using Microsoft.AspNetCore.Mvc;
using OurApi.Interfaces;
using System.Security.Claims;
using OurApi.Models;
using Microsoft.AspNetCore.Authorization;
using OurApi.Services;

namespace OurApi.Controllers;


[ApiController]
[Route("[controller]")]
public class AdminController : GenericController<User>
{

    private readonly TokenService _tokenService;

    public AdminController(IService<User> service, TokenService tokenService) : base(service)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("[action]")]
    public ActionResult<string> Login([FromBody] User user)
    {
        if (!(user.Name == "Tovi" && user.Password == "327773750" 
            || user.Name == "Miri" && user.Password == "BirthDate: 18-05-2005"))
        {
            return Unauthorized();
        }

        var claims = new List<Claim>
        {
            new Claim("type", "Admin")
        };

        // services.AddScoped<TokenService>();

        var token = TokenService.GetToken(claims);

        return new OkObjectResult(TokenService.WriteToken(token));
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Policy="Admin")]
    public IActionResult GenerateBadge([FromBody] User user)
    {
        var claims = new List<Claim>
        {
            new Claim("type", "User")
        };

        var token = TokenService.GetToken(claims);

        return new OkObjectResult(TokenService.WriteToken(token));
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Policy="Admin")]
    public ActionResult<string> AccessClassifiedFiles()
    {
        return new OkObjectResult("classified files accessed");
    }
}