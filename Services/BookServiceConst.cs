// using Microsoft.AspNetCore.Mvc;
using OurApi.Models;
using OurApi.Interfaces;
using OurApi.Services;

namespace OurApi.Services {
    public class BookService:IBookService
    {
        private List<Book> listBooks;
        public BookService()
        {
            listBooks = new List<Book>{
                new Book {Id=1, Name = "איסתרק", Auther = "מיה קינן", Price = 70, Date= DateOnly.FromDateTime(DateTime.Now.AddYears(-2)) },
                new Book {Id=2, Name = "מהלהלל", Auther = "מיה קינן", Price = 70 , Date= DateOnly.FromDateTime(DateTime.Now.AddYears(-2)) }
            };
            System.Console.WriteLine(1);
        }
        public Book Get(int id){
            var book= listBooks.FirstOrDefault(b=> b.Id==id);
    #pragma warning disable CS8603 // Possible null reference return.
            return book;
    #pragma warning restore CS8603 // Possible null reference return.
        }
        public int Insert(Book newBook)
        {
            if(newBook == null ||  String.IsNullOrWhiteSpace(newBook.Name) || newBook.Price <=0 )
                return-1;   
            int MaxId = listBooks.Max(b=> b.Id);
            newBook.Id = MaxId+1;
            listBooks.Add(newBook);
            return newBook.Id;
        }
        public bool Update(int id ,Book book)
        {
            if(book == null || book.Id!=id|| string.IsNullOrWhiteSpace(book.Name) || book.Price <=0)
                return false;
            var currentBook= listBooks.FirstOrDefault(b=> b.Id==id);
            if(currentBook == null)
                return false;
            currentBook.Name = book.Name;
            currentBook.Price = book.Price;
            return true;
        }
        public bool Delete(int id)
        {
            var currentBook= listBooks.FirstOrDefault(b=> b.Id==id);
            if(currentBook == null)
                return false;   
            int index = listBooks.IndexOf(currentBook);
            listBooks.RemoveAt(index);
            return true;
        }

        public List<Book> GetAll()
        {
            Console.WriteLine(2);
            return listBooks;
        }
    }
    // public static class BooksUtilitiesConst
    // {
    //     public static void AddBooksConst(this IServiceCollection services)
    //     {
    //         services.AddSingleton<IBookService, BookService>();
    //     }
    // }
}
