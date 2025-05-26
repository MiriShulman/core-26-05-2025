using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurApi.Interfaces;
using OurApi.Models;
using OurApi.Services;
using System.Linq;

namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : GenericController<Book>
{
    public BookController(IService<Book> service) : base(service)
    {

    }
    [HttpGet("/My-Books/{userId}")]
    public IEnumerable<Book> GetByUserId(int userId)
    {
        ActionResult<IEnumerable<Book>> list = GetAll();
        var books = list.Value as IEnumerable<Book>;
        var filteredBooks = books.Where(b => b.UserId == userId).ToList();
        return filteredBooks;
    }
}