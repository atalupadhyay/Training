using Microsoft.AspNetCore.Mvc;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Controllers
{
    public class GenerateController : Controller
    {
        private readonly ITransient _transient;
        private readonly IScoped _scoped;
        private readonly ISingleton _singleton;

        public GenerateController(
            ITransient transient,
            IScoped scoped,
            ISingleton singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        public IActionResult Index()
        {
            ViewBag.Transient = _transient;
            ViewBag.Scoped = _scoped;
            ViewBag.Singleton = _singleton;

            return View();
        }
    }
}
