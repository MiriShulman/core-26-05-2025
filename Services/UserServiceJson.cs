// using Microsoft.AspNetCore.Mvc;
using OurApi.Models;
using OurApi.Interfaces;
using OurApi.Services;
using System.Collections.Generic;
using System.Linq;
using OurApi.Controllers;

namespace OurApi.Services {

    public class UserServiceJson:ServiceJson<User>
    {

        public UserServiceJson(IHostEnvironment env):base(env, "user.json")
        {
        }

        public override int Insert(User newUser)
        {
            System.Console.WriteLine("insert 1"+newUser);
            if(newUser == null)
            {
                System.Console.WriteLine("Error: this newUser is null");
                return-1;
            }
            if (String.IsNullOrWhiteSpace(newUser.Name))
            {
                System.Console.WriteLine("Error: this  name is required");
                return -1;
            }
            if (String.IsNullOrWhiteSpace(newUser.Address))
            {
                System.Console.WriteLine("Error: this  address is required");
                return -1;
            }
            // if (newUser.BirthDate.ToDateTime(TimeOnly.MinValue) >= DateTime.Now)
            // {
            //     System.Console.WriteLine("Error: BirthDate must be in the past.");
            //     return -1;
            // }
            System.Console.WriteLine("insert 2");
            int maxId = list.Any() ? list.Max(u => u.Id) : 0;
            System.Console.WriteLine("insert 3");
            newUser.Id = maxId + 1;
            list.Add(newUser);
            saveToFile();
            System.Console.WriteLine("insert 4");
            return newUser.Id;
        }
        
        public override bool Update(int id ,User user)
        {
            if(user == null || user.Id!=id
                    || string.IsNullOrWhiteSpace(user.Name)
                    || string.IsNullOrWhiteSpace(user.Address))
                    // || user.BirthDate.ToDateTime(TimeOnly.MinValue) <= DateTime.Now)
                return false;
            var currentUser= list.FirstOrDefault(b=> b.Id==id);
            if(currentUser == null)
                return false;
            currentUser.Name = user.Name;
            currentUser.Address = user.Address;
            // currentUser.BirthDate = user.BirthDate;
            saveToFile();
            return true;
        }

        public List<Book> GetMyBooks(int id){
            return GetBooks(id);
        }

        // public User ValidateUser(LoginRequest request)
        // {
        //     // חפש את המשתמש ברשימה
        //     var user = list.FirstOrDefault(u => u.Name == request.Name && u.Password == request.Password);

        //     // אם נמצא, החזר את המשתמש
        //     return user;
        // }

    }

    // public static class UsersUtilities
    // {
    //     public static void AddUsersJson(this IServiceCollection services)
    //     {
    //         services.AddSingleton<IUserService, UserServiceJson>();
    //     }
    // }
}
