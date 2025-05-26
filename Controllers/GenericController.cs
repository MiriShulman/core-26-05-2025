using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurApi.Interfaces;
using OurApi.Models;
using System.Collections.Generic;

namespace OurApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GenericController<T> : ControllerBase where T : IGeneric
{
    protected readonly IService<T> service;

    public GenericController(IService<T> service)
    {
        this.service = service;
    }
    // [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<T>> GetAll()
    {
        System.Console.WriteLine("get alllllll");
        return service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<T> Get(int id)
    {
        var item = service.Get(id);
        if (item == null)
            throw new ApplicationException($"{typeof(T).Name} not found");
        return item;
    }

    [HttpPost]
    public ActionResult Post(T newItem)
    {
        var newId = service.Insert(newItem);

        if (newId == -1)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Post), new { Id = newId });
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, T item)
    {
        if (service.Update(id, item))
            return NoContent();

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (service.Delete(id))
            return Ok();

        return NotFound();
    }
}