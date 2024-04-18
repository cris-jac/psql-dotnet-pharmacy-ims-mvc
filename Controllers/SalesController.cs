using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;
using PharmaMVC.ViewModels;

namespace PharmaMVC.Controllers;

public class SalesController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ISalesRepository _salesRepository;

    public SalesController(
        IProductRepository productRepository,
        ISalesRepository salesRepository
    )
    {
        _productRepository = productRepository;
        _salesRepository = salesRepository;
    }

    public IActionResult Index()
    {
        return View("Index");
    }

    public async Task<ActionResult> SellProductPartial(int productId)
    {
        var product = await _productRepository.GetProductById(productId);
        return PartialView("_SellProduct", product);
    }

    [HttpPost]
    public async Task<ActionResult> UpdateSaleItem(
        // string userId, int productId, int updateQuantityBy
        SalesViewModel salesViewModel
    )
    {
        var basket = await _salesRepository.GetSalesBasket(salesViewModel.UserId);

        if (basket == null)
        {
            SalesBasket newBasket = new SalesBasket
            {
                UserId = salesViewModel.UserId
            };

            await _salesRepository.AddSalesBasket(newBasket);


            SalesItem newItem = new SalesItem
            {
                ProductId = salesViewModel.ProductId,
                Quantity = salesViewModel.UpdateQuantityBy,
                SalesBasketId = newBasket.Id
                // ,Product = null
            };

            await _salesRepository.AddSalesItem(newItem);

            return View("Index", salesViewModel);
        }
        else
        {
            var salesItemInBasket = basket.SalesItems.FirstOrDefault(x => x.ProductId == salesViewModel.ProductId);

            if (salesItemInBasket == null)
            {
                SalesItem newItem = new SalesItem
                {
                    ProductId = salesViewModel.ProductId,
                    Quantity = salesViewModel.UpdateQuantityBy,
                    SalesBasketId = basket.Id
                    // ,Product = null
                };

                await _salesRepository.AddSalesItem(newItem);

                return View("Index", salesViewModel);
            }
            else
            {
                int newQuantity = salesItemInBasket.Quantity + salesViewModel.UpdateQuantityBy;

                if (newQuantity <= 0)
                {
                    await _salesRepository.RemoveSalesItem(salesItemInBasket);

                    if (basket.SalesItems.Count() == 0)
                    {
                        await _salesRepository.RemoveSalesBasket(basket);
                    }

                    return View("Index", salesViewModel);
                }
                else
                {
                    salesItemInBasket.Quantity = newQuantity;
                    // save changes?
                    return View("Index", salesViewModel);
                }
            }
        }
    }


    [HttpPost]
    public async Task<ActionResult> UpdateSaleItemQuantity(
        int userId, int productId, int updateQuantityBy
    )
    {
        var salesViewModel = new SalesViewModel
        {
            Products = await _productRepository.GetProducts() ?? new List<Product>()
        };
        var basket = await _salesRepository.GetSalesBasket(userId);

        if (basket == null && updateQuantityBy > 0)
        {
            SalesBasket newBasket = new SalesBasket
            {
                UserId = userId
            };

            await _salesRepository.AddSalesBasket(newBasket);
            await _salesRepository.SaveChangesAsync();


            SalesItem newItem = new SalesItem
            {
                ProductId = productId,
                Quantity = updateQuantityBy,
                SalesBasketId = newBasket.Id
                // ,Product = null
            };

            await _salesRepository.AddSalesItem(newItem);
            await _salesRepository.SaveChangesAsync();

            return View("Index", salesViewModel);
        }
        else
        {
            var salesItemInBasket = basket.SalesItems.FirstOrDefault(x => x.ProductId == productId);

            if (salesItemInBasket == null)
            {
                SalesItem newItem = new SalesItem
                {
                    ProductId = productId,
                    Quantity = updateQuantityBy,
                    SalesBasketId = basket.Id
                    // ,Product = null
                };

                await _salesRepository.AddSalesItem(newItem);
                await _salesRepository.SaveChangesAsync();

                return View("Index", salesViewModel);
            }
            else
            {
                int newQuantity = salesItemInBasket.Quantity + updateQuantityBy;

                if (newQuantity <= 0)
                {
                    await _salesRepository.RemoveSalesItem(salesItemInBasket);

                    if (basket.SalesItems.Count() == 0)
                    {
                        await _salesRepository.RemoveSalesBasket(basket);
                    }

                    await _salesRepository.SaveChangesAsync();

                    return View("Index", salesViewModel);
                }
                else
                {
                    salesItemInBasket.Quantity = newQuantity;
                    await _salesRepository.SaveChangesAsync();
                    // save changes?
                    return View("Index", salesViewModel);
                }
            }

        }
    }

    public async Task<ActionResult> CancelSale(int id)
    {
        var basket = await _salesRepository.GetBasketById(id);

        if (basket == null) return NoContent();

        await _salesRepository.RemoveSalesBasket(basket);
        await _salesRepository.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}