using Microsoft.AspNetCore.Mvc;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Controllers;

public class TransactionsController : Controller
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly IProductRepository _productRepository;

    public TransactionsController(
        ITransactionRepository transactionRepository,
        ISalesRepository salesRepository,
        IProductRepository productRepository
    )
    {
        _transactionRepository = transactionRepository;
        _salesRepository = salesRepository;
        _productRepository = productRepository;
    }

    public async Task<ActionResult> Index()
    {
        var transactions = await _transactionRepository.GetTransactions();
        return View(transactions);
    }

    public async Task<ActionResult> CreateTransaction(int basketId)
    {
        var basket = await _salesRepository.GetBasketById(basketId);

        if (basket == null)
        {
            return NoContent();
        }

        var transaction = new Transaction
        {
            UserId = basket.UserId,
            TimeStamp = DateTime.Now
        };

        _transactionRepository.CreateTransaction(transaction);
        await _transactionRepository.SaveChangesAsync();

        foreach (var basketItem in basket.SalesItems)
        {
            var transactionItem = new TransactionItem()
            {
                TransactionId = transaction.Id,
                ProductId = basketItem.ProductId,
                ProductName = basketItem.Product.Name,
                StockBeforeSell = basketItem.Product.Stock,
                StockRemaining = basketItem.Product.Stock - basketItem.Quantity,
                Quantity = basketItem.Quantity,
                UnitPrice = basketItem.Product.Price,
                TaxAmount = basketItem.Product.Price * 0.21 * basketItem.Quantity,
                FinalPrice = basketItem.Product.Price * (1 + 0.21) * basketItem.Quantity
            };

            _transactionRepository.AddTransactionItem(transactionItem);
            await _transactionRepository.SaveChangesAsync();
        }

        transaction.TotalAmount = transaction.TransactionItems.Sum(x => x.FinalPrice);
        await _transactionRepository.SaveChangesAsync();

        // Update the items quantity
        foreach (var item in basket.SalesItems)
        {
            var product = await _productRepository.GetProductById(item.ProductId);
            product.Stock = product.Stock - item.Quantity;
            await _productRepository.UpdateProduct(product.Id, product);
        }

        // Remove the basket once it done with
        await _salesRepository.RemoveSalesBasket(basket);
        await _salesRepository.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

}