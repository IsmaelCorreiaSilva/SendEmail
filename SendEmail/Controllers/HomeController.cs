using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;

namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Email email)
        {         

            if (ModelState.IsValid)
            {
                try{
                    return RedirectToAction("SuccessSend", "Home");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("ErrorSend", "Home");
                }
                
            }
            return View(email);

        }   
        
        public ActionResult SuccessSend()
        {
            return View();
        }
        public ActionResult ErrorSend()
        {
            return View();
        }
    }
}