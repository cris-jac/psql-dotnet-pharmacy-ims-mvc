using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;
using PharmaMVC.Validators;
using PharmaMVC.ViewModels;

namespace PharmaMVC.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<ActionResult<IEnumerable<Category>>> Index()
    {
        var categories = await _categoryRepository.GetCategories();
        return View(categories);
    }

    [HttpGet, Route("/categories/{id}")]
    public async Task<ActionResult<Category>> Details([FromRoute] int id)
    {
        var category = await _categoryRepository.GetCategoryById(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpGet, Route("/categories/add")]
    public IActionResult Add()
    {
        ViewBag.Action = "add";

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromForm] Category category)
    {
        // var category = categoryViewModel.Category;

        if (ModelState.IsValid)
        {
            await _categoryRepository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    [HttpGet, Route("/categories/edit/{id}")]
    public async Task<ActionResult> Edit(int id)
    {
        ViewBag.Action = "edit";

        var category = await _categoryRepository.GetCategoryById(id);
        return View(category);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            await _categoryRepository.UpdateCategory(category.Id, category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    public async Task<ActionResult> Delete(int id)
    {
        var category = await _categoryRepository.GetCategoryById(id);
        await _categoryRepository.DeleteCategory(category);
        return RedirectToAction(nameof(Index));
    }
}