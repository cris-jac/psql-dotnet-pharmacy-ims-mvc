using Microsoft.AspNetCore.Mvc;

namespace PharmaMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}