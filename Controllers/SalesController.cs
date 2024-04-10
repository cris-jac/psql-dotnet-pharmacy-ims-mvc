using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;

namespace PharmaMVC.Controllers;

public class SalesController : Controller
{
    private readonly IProductRepository _productRepository;

    public SalesController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<ActionResult> SellProductPartial(int productId)
    {
        var product = await _productRepository.GetProductById(productId);
        return PartialView("_SellProduct", product);
    }
}