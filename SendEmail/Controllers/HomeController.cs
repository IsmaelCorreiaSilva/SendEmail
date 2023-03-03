using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using System.Diagnostics;

namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Email email)
        {

            if (!ModelState.IsValid)
            {
                RedirectToAction("SuccessSend", "Home");
            }
            return View();

        }
    }
}