using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;

namespace PharmaMVC.Controllers;

public class HomeController : Controller
{
    private readonly ITransactionRepository _transactionRepository;

    public HomeController(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return View();
        }
        return RedirectToAction("Login", "Account");
    }


    public async Task<IActionResult> SalesByPeriod(
        // DateTime startDate, DateTime endDate
        )
    {
        var startDate = new DateTime(2024, 01, 01);
        var endDate = new DateTime(2024, 12, 31);
        var sales = await _transactionRepository.GetTransactionsByTimePeriod(startDate, endDate);

        ViewBag.TransactionData = Newtonsoft.Json.JsonConvert.SerializeObject(sales);

        return View();
    }
}