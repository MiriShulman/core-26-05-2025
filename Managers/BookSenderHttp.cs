
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using OurApi.Models;
using OurApi.Interfaces;

namespace OurApi.Managers
{
    public class BookSenderHttp: IBookSender {
        private static readonly HttpClient httpClient = new HttpClient();

        public Task<string> Send(Book book)
        {
            var jsonBooks = JsonSerializer.Serialize<Book>(book);
            var stringContent = new StringContent(jsonBooks, UnicodeEncoding.UTF8, "application/json");
            var response = httpClient.PostAsync("https://mymicroservice/myendpoint", stringContent);
            // return response.Content.ReadAsStringAsync().Result;
            return response.Content.ReadAsStringAsync().Result;

        }
    }   
}