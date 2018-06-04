using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using APIDemo.Services;
using APIDemo.Dtos;
using APIDemo.Helpers;

namespace APIDemo.Controllers
{
    [AllowAnonymous]
    [Route("api/v2/Cars")]
    public class Cars2Controller : Controller
    {
        private readonly ICarsRepository _repo;
        private readonly IMapper _mapper;

        public Cars2Controller(ICarsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars (ResourceParameters parameters)
        {
            var cars = await _repo.GetAll(parameters);

            var carsDto = _mapper.Map<IList<CarDto>>(cars);

            return Ok(carsDto);
        }
    }
}