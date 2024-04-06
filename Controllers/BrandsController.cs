using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    [HttpGet, Route("/brands/{id}")]
    public async Task<ActionResult<Brand>> Details([FromRoute] int id)
    {
        var brand = await _brandRepository.GetBrandById(id);

        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromForm] Brand brand)
    {
        if (ModelState.IsValid)
        {
            await _brandRepository.AddBrand(brand);
            return RedirectToAction(nameof(Index));
        }

        return View(brand);
    }

    [HttpGet, Route("/brands/edit/{id}")]
    public async Task<ActionResult> Edit([FromRoute] int id)
    {
        var brand = await _brandRepository.GetBrandById(id);
        return View(brand);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Brand brand)
    {
        if (ModelState.IsValid)
        {
            await _brandRepository.UpdateBrand(brand.Id, brand);
            return RedirectToAction(nameof(Index));
        }

        return View(brand);
    }

    public async Task<ActionResult> Delete(int id)
    {
        var brand = await _brandRepository.GetBrandById(id);
        await _brandRepository.DeleteBrand(brand);
        return RedirectToAction(nameof(Index));
    }
}