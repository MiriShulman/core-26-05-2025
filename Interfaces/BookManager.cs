using OurApi.Models;

namespace OurApi.Interfaces{
    public interface IBookManager{
        Task<string> Transmit(Book book);
    }
}
