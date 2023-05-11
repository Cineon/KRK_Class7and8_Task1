using KRK_Class7_Task1.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace KRK_Class7_Task1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAll());
        }
    }
}
