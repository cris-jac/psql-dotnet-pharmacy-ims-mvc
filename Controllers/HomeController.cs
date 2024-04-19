using Microsoft.AspNetCore.Mvc;

namespace PharmaMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return View();
        }
        return RedirectToAction("Login", "Account");
    }
}