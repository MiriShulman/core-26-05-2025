using System.Reflection.Metadata.Ecma335;
using OurApi.Interfaces;

namespace OurApi.Models;

public class CurrentController: IGeneric
{
    public string Type {get; set;}
    public int Id { get; set; }

    public CurrentController(int id, string type)
    {
        this.Id = id;
        this.Type = type;
    }
}