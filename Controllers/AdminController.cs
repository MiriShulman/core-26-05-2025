// using Microsoft.AspNetCore.Mvc;
// using OurApi.Interfaces;
// using System.Security.Claims;
// using OurApi.Models;
// using Microsoft.AspNetCore.Authorization;
// using OurApi.Services;

// namespace OurApi.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class AdminController : GenericController<User>
// {

//     private readonly TokenService _tokenService;
//     private readonly GenericController<User> _genericController;

//     public AdminController(IService<User> service, TokenService tokenService) : base(service)
//     {
//         // _genericController = new GenericController<User>();
//         _tokenService = tokenService;
//     }

//     // [HttpPost]
//     // [Route("[action]")]
//     // [Authorize(Policy="Admin")]
//     // public IActionResult GenerateBadge([FromBody] User user)
//     // {
//     //     var claims = new List<Claim>
//     //     {
//     //         new Claim("type", "User")
//     //     };

//     //     var token = TokenService.GetToken(claims);

//     //     return new OkObjectResult(TokenService.WriteToken(token));
//     // }

//     [HttpGet]
//     [Route("[action]")]
//     [Authorize(Policy="Admin")]
//     public ActionResult<string> AccessClassifiedFiles()
//     {
//         return new OkObjectResult("classified files accessed");
//     }

//     // [HttpPost]
//     // [Authorize(Policy="Admin")]
//     // public ActionResult Post(User user)
//     // {
//     //     return GenericController<User>.Post(user);
//     // }
// }
