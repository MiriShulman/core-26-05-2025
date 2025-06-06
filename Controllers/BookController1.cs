using Microsoft.AspNetCore.Mvc;
using OurApi.Interfaces;
using OurApi.Models;
namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController1 : ControllerBase
{

    private IService<Book> bookService;
    public BookController1(IService<Book> bookService){
        this.bookService=bookService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get()
    {
        return bookService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = bookService.Get(id);
        if (book == null)
            //return NotFound();
            throw new ApplicationException("book not found");
        return book;
    }

    [HttpPost]
    public ActionResult Post(Book newBook)
    {
        var newId = bookService.Insert(newBook);
        if (newId == -1)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Post), new { Id = newId });
    }

    [HttpPut("{id}")]
    public  ActionResult Put(int id, Book book)
    {
        
        if(bookService.Update(id,book))
            return NoContent();
        
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
         if(bookService.Delete(id))
            return Ok();

        return NotFound();
    }

    
}