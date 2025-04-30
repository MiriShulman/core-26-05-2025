using OurApi.Interfaces;

namespace OurApi.Models;

public class Admin: User {
    // public string name {get; set;}
    public int ClearanceLevel { get; set; }

}