using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandRepository _brandRepository;

    public BrandsController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<ActionResult<IEnumerable<Brand>>> Index()
    {
        var brands = await _brandRepository.GetBrands();
        return View(brands);
    }
}