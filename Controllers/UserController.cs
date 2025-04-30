using Microsoft.AspNetCore.Mvc;
using OurApi.Interfaces;
using OurApi.Models;
namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : GenericController<User>
{
    public UserController(IService<User> service) : base(service)
    {
    }

    [HttpGet]
    [Route("[action]")]
    public ActionResult<string> AccessPublicFiles()
    {
        return new OkObjectResult("public files accessed");
    }

}