using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;
using PharmaMVC.ViewModels;

namespace PharmaMVC.Controllers;

public class SubcategoriesController : Controller
{
    private readonly ISubcategoryRepository _subcategoryRepository;
    private readonly ICategoryRepository _categoryRepository;

    public SubcategoriesController(
        ISubcategoryRepository subcategoryRepository,
        ICategoryRepository categoryRepository)
    {
        _subcategoryRepository = subcategoryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ActionResult> Index()
    {
        var subcategories = await _subcategoryRepository.GetSubcategories();
        return View(subcategories);
    }

    [HttpGet, Route("/subcategories/{id}")]
    public async Task<ActionResult> Details([FromRoute] int id)
    {
        var subcategory = await _subcategoryRepository.GetSubcategoryById(id);

        if (subcategory == null)
        {
            return NotFound();
        }

        return View(subcategory);
    }

    [HttpGet, Route("/subcategories/edit/{id}")]
    public async Task<ActionResult> Edit([FromRoute] int id)
    {
        ViewBag.Action = "edit";

        var subcategoryViewModel = new SubcategoryViewModel
        {
            Subcategory = await _subcategoryRepository.GetSubcategoryById(id) ?? new Subcategory(),
            Categories = await _categoryRepository.GetCategories()
        };
        return View(subcategoryViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(SubcategoryViewModel subcategoryViewModel)
    {
        if (ModelState.IsValid)
        {
            var subcategory = subcategoryViewModel.Subcategory;
            await _subcategoryRepository.UpdateSubcategory(subcategory.Id, subcategory);
            return RedirectToAction(nameof(Index));
        }

        subcategoryViewModel.Categories = await _categoryRepository.GetCategories();
        return View(subcategoryViewModel);
    }

    [HttpGet, Route("/subcategories/add")]
    public async Task<ActionResult> Add()
    {
        ViewBag.Action = "add";

        var subcategoryViewModel = new SubcategoryViewModel
        {
            Categories = await _categoryRepository.GetCategories()
        };
        return View(subcategoryViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromForm] SubcategoryViewModel subcategoryViewModel)
    {

        if (ModelState.IsValid)
        {
            var subcategory = subcategoryViewModel.Subcategory;
            await _subcategoryRepository.AddSubcategory(subcategory);
            return RedirectToAction(nameof(Index));
        }

        subcategoryViewModel.Categories = await _categoryRepository.GetCategories();
        return View(subcategoryViewModel);
    }
}