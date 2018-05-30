using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class HelperController : Controller
    {
        public IActionResult Index()
        {
            #region TempData
            TempData["Engine"] = "Please refill petrol...";
            ViewData["Message"] = "Hello from ViewData";
            #endregion

            #region UseCookies
            SetCookie("Car", "PPEDV 2018", 5);

            var keks = Request.Cookies["Car"];

            Response.Cookies.Delete("Car");
            #endregion

            return View();
        }

        #region Cookies
        private void SetCookie(string key, string value, int? expireTime)
        {
            var options = new CookieOptions();
            if (expireTime.HasValue)
            {
                options.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                options.Expires = DateTime.Now.AddMilliseconds(10);
            }
            Response.Cookies.Append(key, value, options);
        }
        #endregion

        #region Error
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        #region ErrorCustom
        public IActionResult ErrorCustom(int? statusCode)
        {
            var error = new ErrorCustomViewModel();
            if (statusCode == 404 || statusCode == 500)
            {
                error.Message = statusCode.ToString();
            }
            return View("ErrorCustom", error);
        }
        #endregion
    }
}
