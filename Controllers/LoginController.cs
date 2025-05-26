using Microsoft.AspNetCore.Mvc;
using OurApi.Services;
using System.Security.Claims;
using OurApi.Models;
using OurApi.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;

namespace OurApi.Controllers;

public class LoginRequest
{
    public string Name { get; set; }
    public string Password { get; set; }
}

[ApiController]
// [Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly LoginService _loginService;
    private readonly GenericController<User> _genericController;
    protected readonly IService<User> _service;
    private readonly KeyGenerator _keyGenerator;
    public LoginController(IOptions<JWTSettings> jwtSettings, IService<User> service, LoginService loginService)
    {
        _keyGenerator = new KeyGenerator(jwtSettings);
        _service = service;
        _loginService = loginService;
        _genericController = new GenericController<User>(_service);

    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User user)
    {

        var claims = new List<Claim>();
        ActionResult<IEnumerable<User>> list2 = _genericController.GetAll();
        List<User> list = list2.Value.ToList();
        
        // if ((user.Name == "Tovi" && user.Password == "327773750" 
        //     || user.Name == "Miri" && user.Password == "BirthDate: 18-05-2005"))
        // {
        //     claims.Add(new Claim("type", "Admin")); // הוספת הרשאת Admin
        // }

        if (list.Any(l => l.Name == user.Name && l.Password == user.Password))
            claims = new List<Claim>{
                new Claim("type", user.Type),
                new Claim("Id", user.Id.ToString())
            };
        else
            return Unauthorized();

        // כאן תוכל להוסיף לוגיקה לבדוק את פרטי המשתמש
        String token = _keyGenerator.GenerateRandomKey(33, claims);

        if (token.Length < 32) // 32 bytes = 256 bits
        {
            throw new ArgumentException("The secret key must be at least 256 bits long.");
        }

        // שמירת הטוקן בעוגיה
        Response.Cookies.Append("JWT", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });

        var claimsIdentity = new ClaimsIdentity(claims, "login");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        HttpContext.SignInAsync(claimsPrincipal);

        return Ok(new { Message = "Login successful" });
    }
}