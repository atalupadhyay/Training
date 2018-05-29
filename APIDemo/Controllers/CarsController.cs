using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDemo.Models;
using Microsoft.AspNetCore.Authorization;
using APIDemo.Services;

namespace APIDemo.Controllers
{
    //[Produces("application/json")]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarsRepository _repo;
        #region constructorOhneRepo
        //private readonly ApiDemoContext _ctx;

        //public CarsController(ApiDemoContext ctx)
        //{
        //    _ctx = ctx;

        //    //if (_ctx.Cars.Count() == 0)
        //    //{
        //    //    _ctx.Cars.Add(new Car
        //    //    {
        //    //        BrandName = BrandNames.DMC,
        //    //        ModelName = "Delorian",
        //    //        YearOfConstruction = 1985
        //    //    });
        //    //    _ctx.SaveChanges();
        //    //}
        //}
        #endregion

        public CarsController(ICarsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _repo.GetAll();
            return Ok(cars);
        }

        // GET: api/Cars/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCar([FromRoute] int id)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //var car = await _ctx.Cars.FindAsync(id);

        //    //if (car == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return Ok(car);
        //}

        // PUT: api/Cars/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCar([FromRoute] int id, [FromBody] Car car)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != car.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _ctx.Entry(car).State = EntityState.Modified;

        //    try
        //    {
        //        await _ctx.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Cars
        //[HttpPost]
        //public async Task<IActionResult> PostCar([FromBody] Car car)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //_ctx.Cars.Add(car);
        //    //await _ctx.SaveChangesAsync();

        //    //return CreatedAtAction("GetCar", new { id = car.Id }, car);
        //}

        // DELETE: api/Cars/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCar([FromRoute] int id)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //var car = await _ctx.Cars.FindAsync(id);
        //    //if (car == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //_ctx.Cars.Remove(car);
        //    //await _ctx.SaveChangesAsync();

        //    //return Ok(car);
        //}

        //private bool CarExists(int id)
        //{
        //    return _ctx.Cars.Any(e => e.Id == id);
        //}
    }
}