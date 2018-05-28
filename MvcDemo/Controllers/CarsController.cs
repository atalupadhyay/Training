using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class CarsController : Controller
    {
        private readonly MvcDemoContext _ctx;

        public CarsController(MvcDemoContext ctx)
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

        // GET: Cars
        //[CustomExceptionFilter]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            //try
            //{
            //throw new NullReferenceException("Computer says No!");
            //
            //var cars = await _ctx.Cars.ToListAsync();
            //
            //return View(cars);
            //
            //}
            //catch (Exception ex)
            //{
            //    return new StatusCodeResult(500);               
            //}

            //return View(await _ctx.Cars.ToListAsync());

            return View();
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _ctx.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandName,ModelName,YearOfConstruction")] Car car)
        {
            if (ModelState.IsValid)
            {
                _ctx.Add(car);
                await _ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _ctx.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandName,ModelName,YearOfConstruction")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ctx.Update(car);
                    await _ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _ctx.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _ctx.Cars.FindAsync(id);
            _ctx.Cars.Remove(car);
            await _ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _ctx.Cars.Any(e => e.Id == id);
        }

        public IActionResult Test(string id)
        {
            return Content(id.ToString());
        }
    }
}
