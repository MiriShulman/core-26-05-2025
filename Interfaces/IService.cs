using OurApi.Models;

namespace OurApi.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T Get(int id);
        int Insert(T newT);
        bool Delete(int id);
        bool Update(int id, T t);
    }
}