
using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;
using PharmaMVC.ViewModels;

namespace PharmaMVC.Controllers;

public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ISubcategoryRepository _subcategoryRepository;
    private readonly IBrandRepository _brandRepository;

    public ProductsController(
        IProductRepository productRepository,
        ISubcategoryRepository subcategoryRepository,
        IBrandRepository brandRepository
    )
    {
        _productRepository = productRepository;
        _subcategoryRepository = subcategoryRepository;
        _brandRepository = brandRepository;
    }

    public async Task<ActionResult> Index()
    {
        var products = await _productRepository.GetProducts();
        return View(products);
    }

    public async Task<ActionResult> Details(int id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpGet, Route("/products/edit/{id}")]
    public async Task<ActionResult> Edit(int id)
    {
        ViewBag.Action = "edit";

        var productViewModel = new ProductViewModel
        {
            Product = await _productRepository.GetProductById(id) ?? new Product(),
            Subcategories = await _subcategoryRepository.GetSubcategories(),
            Brands = await _brandRepository.GetBrands(),
        };

        return View(productViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            var product = productViewModel.Product;
            await _productRepository.UpdateProduct(product.Id, product);
            return RedirectToAction(nameof(Index));
        }

        productViewModel.Subcategories = await _subcategoryRepository.GetSubcategories();
        productViewModel.Brands = await _brandRepository.GetBrands();
        return View(productViewModel);
    }

    [HttpGet, Route("/products/add")]
    public async Task<ActionResult> Add()
    {
        ViewBag.Action = "add";

        var productViewModel = new ProductViewModel
        {
            Subcategories = await _subcategoryRepository.GetSubcategories(),
            Brands = await _brandRepository.GetBrands()
        };

        return View(productViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Add(ProductViewModel productViewModel)
    {

        if (ModelState.IsValid)
        {
            var product = productViewModel.Product;
            await _productRepository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        productViewModel.Subcategories = await _subcategoryRepository.GetSubcategories();
        productViewModel.Brands = await _brandRepository.GetBrands();
        return View(productViewModel);
    }

    [HttpGet]
    public async Task<ActionResult> FilteredProducts(string searchString)
    {
        var result = await _productRepository.SearchProducts(searchString);
        return View(result);
    }
}