// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Threading.Tasks;
// using OurApi.Models;
// using System.Text;
// using OurApi.Controllers;
// using Newtonsoft.Json;
// using Microsoft.AspNetCore.Mvc;
// // using OurApi.Interfaces;
// // using System.Security.Claims;
// // using OurApi.Services;
// // using Microsoft.AspNetCore.Authorization;
// namespace OurApi.Services;

// public class ApiService: ControllerBase
// {
//     private readonly HttpClient _client;

//     public ApiService(HttpClient client)
//     {
//         _client = client;
//     }

//     public async Task<String> PostDataAsync(string token, User newItem)
//     {
        
//         // הגדרת כותרת האישור
//         _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//         // שליחת הבקשה
//         var response = await _client.PostAsJsonAsync("https://yourapi.com/api/controller/Post", newItem);
        
//         // בדיקת התגובה
//         if (response.IsSuccessStatusCode)
//         {
//             // var jsonString = await httpContent.ReadAsStringAsync();
//             // var post = JsonConvert.DeserializeObject<Post>(jsonString);     
//             //        // עשה משהו עם התוצאה
//             // return post;
//             using (HttpClient client = new HttpClient())
//             {
//                 string jsonString = JsonConvert.SerializeObject(newItem);
//                 HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json"); // הגדרת httpContent
                
//                 HttpResponseMessage response2 = await client.PostAsync(token, httpContent); // שימוש ב-httpContent
//                 return await response2.Content.ReadAsStringAsync();
//             }
//         }
//         else
//         {
//             // טיפול בשגיאה
//             // לדוגמה, ניתן לזרוק יוצא דופן או להחזיר ערך ברירת מחדל
//             throw new HttpRequestException($"Error: {response.StatusCode}");
//         }
//     }
// }