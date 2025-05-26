// using Microsoft.AspNetCore.Mvc;
using OurApi.Models;
using OurApi.Interfaces;
using OurApi.Services;
using System.Collections.Generic;

namespace OurApi.Services {

    public class BookServiceJson:ServiceJson<Book>
    {

        public BookServiceJson(IHostEnvironment env):base(env, "book.json")
        {
        }

        public override int Insert(Book newBook)
        {

            System.Console.WriteLine("insert 1"+newBook);
            if(newBook == null)
            {
                System.Console.WriteLine("Error: this newBook is null");
                return-1;
            }
            if (String.IsNullOrWhiteSpace(newBook.Name))
            {
                System.Console.WriteLine("Error: this  name is required");
                return -1;
            }
            if (newBook.Price <= 0)
            {
                System.Console.WriteLine("Error: this  price is < 0");
                return -1;
            }
            System.Console.WriteLine("insert 2");
            int maxId = list.Any() ? list.Max(b => b.Id) : 0;
            System.Console.WriteLine("insert 3");
            newBook.Id = maxId + 1;
            list.Add(newBook);
            saveToFile();
            System.Console.WriteLine("insert 4");
            return newBook.Id;
        }
        
        public override bool Update(int id ,Book book)
        {
            if(book == null || book.Id!=id
                    || string.IsNullOrWhiteSpace(book.Name)
                    || book.Price <= 0)
                return false;
            var currentBook= list.FirstOrDefault(b=> b.Id==id);
            if(currentBook == null)
                return false;
            currentBook.Name = book.Name;
            currentBook.Price = book.Price;
            saveToFile();
            return true;
        }

        // public List<Book> GetByUserId(int userId){
            
        // }

    }

    // public static class BooksUtilities
    // {
    //     public static void AddBooksJson(this IServiceCollection services)
    //     {
    //         services.AddSingleton<IBookService, BookServiceJson>();
    //     }
    // }

}
