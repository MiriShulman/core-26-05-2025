using OurApi.Models;
// using System.Collections.Generic;

namespace OurApi.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book Get(int id);
        int Insert(Book newBook);
        bool Delete(int id);
        bool Update(int id, Book book);
    }
}