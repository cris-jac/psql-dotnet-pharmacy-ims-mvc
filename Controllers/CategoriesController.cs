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
        // var addCategoryViewModel = new AddCategoryViewModel
        // {
        //     Category = new Category()
        // };
        // return View(addCategoryViewModel);
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromForm] AddCategoryViewModel categoryViewModel)
    {
        var category = categoryViewModel.Category;

        if (ModelState.IsValid)
        {
            await _categoryRepository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }
        return View(categoryViewModel);
        // CategoryValidator validator = new CategoryValidator();
        // ValidationResult result = validator.Validate(category);

        // if (result.IsValid)
        // {
        //     await _categoryRepository.AddCategory(category);
        //     return RedirectToAction(nameof(Index));
        // }
        // else
        // {
        //     foreach (ValidationFailure failure in result.Errors)
        //     {
        //         ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
        //         Console.WriteLine($"Validation error: Prop - {failure.PropertyName}");
        //     }
        // }
        // return View(category);
    }

    [HttpGet, Route("/categories/edit/{id}")]
    public async Task<ActionResult> Edit(int id)
    {
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
}