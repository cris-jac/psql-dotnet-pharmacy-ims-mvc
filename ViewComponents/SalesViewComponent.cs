using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;

namespace PharmaMVC.ViewComponents;

[ViewComponent]
public class SalesViewComponent : ViewComponent
{
    private readonly ISalesRepository _salesRepository;

    public SalesViewComponent(ISalesRepository salesRepository)
    {
        _salesRepository = salesRepository;
    }
    public async Task<IViewComponentResult> InvokeAsync(string userId)
    {
        var basket = await _salesRepository.GetSalesBasket(userId);
        return View(basket);        // Passed to Sales.Default.cshtml
    }
}