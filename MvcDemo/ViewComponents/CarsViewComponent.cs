using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcDemo.Models;

namespace MvcDemo.ViewComponents
{
    public class CarsViewComponent : ViewComponent
    {
        private readonly MvcDemoContext _ctx;

        public CarsViewComponent(MvcDemoContext ctx)
        {
            _ctx = ctx;

            if (_ctx.Cars.Count() == 0)
            {
                _ctx.Cars.Add(
                    new Car
                    {
                        BrandName = "DMC",
                        ModelName = "Delorian",
                        YearOfConstruction = 1985
                    });
                _ctx.SaveChanges();
            }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _ctx.Cars.ToListAsync());
        }
    }
}
