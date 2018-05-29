using APIDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIDemo.Services
{
    public interface ICarsRepository : IRepository<Car>
    {
        Task<IEnumerable<Car>> GetCarsWithDiscount();
    }
}
