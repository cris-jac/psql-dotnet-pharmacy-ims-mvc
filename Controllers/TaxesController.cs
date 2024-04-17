using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Controllers;

public class TaxesController : Controller
{
    private readonly ITaxRepository _taxRepository;

    public TaxesController(ITaxRepository taxRepository)
    {
        _taxRepository = taxRepository;
    }

    public async Task<IActionResult> Index()
    {
        var taxes = await _taxRepository.GetTaxes();
        return View(taxes);
    }

    [HttpGet, Route("/taxes/{id}")]
    public async Task<ActionResult<Tax>> Details([FromRoute] int id)
    {
        var tax = await _taxRepository.GetTaxById(id);

        if (tax == null) return NotFound();

        return View(tax);
    }

    [HttpGet, Route("/taxes/add")]
    public IActionResult Add()
    {
        ViewBag.Action = "add";

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromForm] Tax tax)
    {
        if (ModelState.IsValid)
        {
            await _taxRepository.AddTax(tax);
            return RedirectToAction(nameof(Index));
        }

        return View(tax);
    }

    [HttpGet, Route("/tax/edit/{id}")]
    public async Task<ActionResult> Edit([FromRoute] int id)
    {
        ViewBag.Action = "edit";

        var tax = await _taxRepository.GetTaxById(id);
        return View(tax);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Tax tax)
    {
        if (ModelState.IsValid)
        {
            await _taxRepository.UpdateTax(tax.Id, tax);
            return RedirectToAction(nameof(Index));
        }

        return View(tax);
    }

    public async Task<ActionResult> Delete(int id)
    {
        var tax = await _taxRepository.GetTaxById(id);
        await _taxRepository.DeleteTax(tax);
        return RedirectToAction(nameof(Index));
    }
}