using System.Diagnostics;
using OurApi.Interfaces;
using OurApi.Models;

namespace OurApi.Managers{
    public class BookManager : IBookManager
    {
        private IBookSender bookSender;
        public BookManager(IBookSender bookSender){
            this.bookSender = bookSender;
        }
        public async Task<string> Transmit(Book book)
        {
            return await bookSender.Send(book);
        }
    }
}