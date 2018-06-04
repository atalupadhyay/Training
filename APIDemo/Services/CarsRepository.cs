using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIDemo.Models;
using APIDemo.Helpers;

namespace APIDemo.Services
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ApiDemoContext _ctx;

        public CarsRepository(ApiDemoContext ctx)
        {
            _ctx = ctx;

            if (_ctx.Cars.Count() == 0)
            {
                _ctx.Cars.Add(new Car
                {
                    BrandName = BrandNames.DMC,
                    ModelName = "Delorian",
                    YearOfConstruction = 1985,
                    IdentificationNumber = Guid.NewGuid()
                });
                _ctx.SaveChanges();
            }
        }

        public async Task<IEnumerable<Car>> GetAll(ResourceParameters parameters)
        {
            return await _ctx.Cars
                .Skip(parameters.PageSize * (parameters.PageNumber - 1))
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        public async Task<Car> FindById(int id)
        {
            var car = await _ctx.Cars.FindAsync(id);
            return car;
        }

        public void Add(Car entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _ctx.Cars.Add(entity);
        }


        public void Remove(Car entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _ctx.Cars.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }

        public Task<IEnumerable<Car>> GetCarsWithDiscount()
        {
            // Extra Logik kann überlegt werden
            throw new NotImplementedException();
        }

        // sicher ist sicher...
        ~CarsRepository()
        {
            _ctx.Dispose();
        }
    }
}
