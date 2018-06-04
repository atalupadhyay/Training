using APIDemo.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIDemo.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(ResourceParameters parameters);
        Task<T> FindById(int id);

        void Add(T entity);
        void Remove(T entity);

        Task<bool> SaveAll();
    }
}
