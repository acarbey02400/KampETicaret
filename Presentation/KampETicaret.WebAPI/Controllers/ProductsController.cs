using KampETicaret.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KampETicaret.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService=productService;
        }
        [HttpGet]
        public IActionResult GetProductsList()
        {
            return Ok(_productService.GetProductsList());
        }
    }
}
