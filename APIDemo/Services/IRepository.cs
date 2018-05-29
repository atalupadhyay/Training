using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIDemo.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int id);

        void Add(T entity);
        void Remove(T entity);

        Task<bool> SaveAll();
    }
}
