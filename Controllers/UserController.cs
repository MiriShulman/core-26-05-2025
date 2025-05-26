using Microsoft.AspNetCore.Mvc;
using OurApi.Interfaces;
using System.Security.Claims;
using OurApi.Models;
using Microsoft.AspNetCore.Authorization;
using OurApi.Services;

// דוגמא מGPT-משופר
// [ApiController]
// [Route("[controller]")]
// public class UserController : GenericController<User>
// {
//     private readonly TokenService _tokenService;

//     public UserController(IService<User> service, TokenService tokenService) : base(service)
//     {
//         _tokenService = tokenService;
//     }

//     [HttpGet]
//     [Route("[action]")]
//     public ActionResult<string> AccessPublicFiles()
//     {
//         return Ok("public files accessed");
//     }

//     [HttpGet]
//     [Route("[action]")]
//     [Authorize(Policy = "Admin")]
//     public ActionResult<string> AccessClassifiedFiles()
//     {
//         return Ok("classified files accessed");
//     }

//     [HttpGet]
//     [Route("[action]")]
//     [Authorize(Policy = "Admin")]
//     public ActionResult<IEnumerable<User>> GetAll()
//     {
//         return base.GetAll(); // אם אתה משתמש בהירושה
//     }
// }



namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly TokenService _tokenService;
    protected readonly IService<User> service;
    private readonly GenericController<User> _genericController;

    public UserController(IService<User> service, TokenService tokenService)
    {
        this.service = service;
        _genericController = new GenericController<User>(this.service);
        _tokenService = tokenService;
    }
    
    // [HttpGet]
    // // [Route("[action]")]
    // public ActionResult<string> AccessPublicFiles()
    // {
    //     return new OkObjectResult("public files accessed");
    // }

    // [HttpGet]
    // // [Route("[action]")]
    // [Authorize(Policy="Admin")]
    // public ActionResult<string> AccessClassifiedFiles()
    // {
    //     return new OkObjectResult("classified files accessed");
    // }

    // [HttpPost]
    // // [Route("[action]")]
    // [Authorize(Policy="Admin")]
    // public async Task<ActionResult> Post(String token, User newUser) {
    //     var result = await ApiService.PostDataAsync(token, newUser);
    //     return Ok(result);
    // }

    [HttpGet]
    // [Route("Get")]
    [Authorize(AuthenticationSchemes ="Bearer")]
    public IEnumerable<User> GetAll(){
        System.Console.WriteLine("\n you enter???");
        System.Console.WriteLine();
        System.Console.WriteLine("asdf");
        IEnumerable<User> a=service.GetAll();
        return a;
    }
}