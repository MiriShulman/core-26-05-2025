using OurApi.Models;

namespace OurApi.Interfaces{
    public interface IBookSender{
        Task<String> Send(Book book);
    }
}