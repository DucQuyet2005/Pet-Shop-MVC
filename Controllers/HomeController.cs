using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
    {
        _logger = logger;
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProductsAsync();
        var categories = await _categoryService.GetAllCategoriesAsync();
        ViewBag.Products = products;
        ViewBag.Categories = categories;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
