// using Microsoft.AspNetCore.Mvc;
// using OurApi.Interfaces;
// using OurApi.Models;
// // using OurApi.Services;
// namespace OurApi.Controllers;
// [ApiController]
// [Route("[controller]")]
// public class BookController : ControllerBase
// {
//     private IBookService BookService;

//     public BookController(IBookService BookService)
//     {
//         this.BookService = BookService;
//     }

//     [HttpGet]
//     public ActionResult<IEnumerable<Book>> GetAll()
//     {
//         System.Console.WriteLine(3);
//         return BookService.GetAll();
//     }
//     [HttpGet("{id}")]
//     public ActionResult<Book> Get(int id)
//     {
//         var book = BookService.Get(id);
//         if (book == null)
//             return NotFound();
//         return book;
//     }
//     [HttpPost]
//     public ActionResult Post(Book newBook)
//     {
//         var newId = BookService.Insert(newBook);
//         if (newId == -1)
//         {
//             return BadRequest();
//         }
//         return CreatedAtAction(nameof(Post), new { Id = newId });
//     }
//     [HttpPut("{id}")]
//     public  ActionResult Put(int id, Book book)
//     {
//         if(BookService.Update(id,book))
//             return NoContent();

//         return BadRequest();
//     }
//     [HttpDelete("{id}")]
//     public ActionResult Delete(int id)
//     {
//          if(BookService.Delete(id))
//             return Ok();
//         return NotFound();
//     }
// }

using Microsoft.AspNetCore.Mvc;
using OurApi.Interfaces;
using OurApi.Models;
namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : GenericController<Book>
{
    public BookController(IService<Book> service) : base(service)
    {
    }
}