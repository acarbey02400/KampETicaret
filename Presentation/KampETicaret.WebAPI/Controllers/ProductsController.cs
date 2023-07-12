using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KampETicaret.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;

        public ProductsController(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        [HttpGet]
        public Task<List<Product>> GetAllAsync()
        {
            return _readRepository.GetAllAsync();
        }
        [HttpPost("addasync")]
        public Task<Product> AddAsync([FromBody]Product product)
        {
            return _writeRepository.AddAsync(product);
        }
    }
}
