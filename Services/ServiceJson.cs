// using Microsoft.AspNetCore.Mvc;
using OurApi.Models;
using OurApi.Interfaces;
using OurApi.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace OurApi.Services {

    public abstract class ServiceJson<T>:IService<T> where T: IGeneric
    {
        protected List<T> list { get; }
        protected static string fileName;
        private string filePath;

        public ServiceJson(IHostEnvironment env, string fName)
        {
            fileName = fName;
            filePath = Path.Combine(env.ContentRootPath, "Data", fileName);
            if (!File.Exists(filePath))
            {
                System.Console.WriteLine("--------------------------------------------------");
                list = new List<T>(); // או טיפול אחר במקרה שהקובץ לא קיים
                return;

            }

            using (var jsonFile = File.OpenText(filePath))
            {
                System.Console.WriteLine("////////////////////////////////////////////////");

                list = JsonSerializer.Deserialize<List<T>>(jsonFile.ReadToEnd(),
                        new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<T>(); ;
                System.Console.WriteLine(list.ToString()+"-------------------------------------------------------------------");

            }
        }

         protected void saveToFile()
        {
            System.Console.WriteLine("in save to file----------------------------" + filePath);
            File.WriteAllText(filePath, JsonSerializer.Serialize(list));
        }

        public T Get(int id){
            var t= list.FirstOrDefault(l=> l.Id==id);
            return t;
        }

        public List<Book> GetBooks(int userId){
            return new List<Book>();
        }

        public abstract int Insert(T newT);
        
        public abstract bool Update(int id ,T t);
        
        public bool Delete(int id)
        {
            var currentT= list.FirstOrDefault(b=> b.Id==id);
            if(currentT == null)
                return false;   
            int index = list.IndexOf(currentT);
            list.RemoveAt(index);
            return true;
        }

        public List<T> GetAll()
        {
            return list;
        }
    }
    public static class ServiceUtilities
    {
        public static void AddGenericConst(this IServiceCollection services)
        {
            services.AddSingleton<IService<Book>, BookServiceJson>();
            services.AddSingleton<IService<User>, UserServiceJson>();
        }
    }
}
