using KampETicaret.Application.Dtos;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Application.RequestParameters;
using KampETicaret.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

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

        [HttpGet("getallasync")]
        public async Task<ActionResult> GetAllAsync([FromQuery]Pagination pagination)
        {
            var result = await _readRepository.GetAllAsync();
           
            return Ok
            (
                result.Skip(pagination.Page * pagination.Size)
                .Take(pagination.Size)
               .ToList()
            );
        }

        [HttpGet("getbyidasync")]
        public Task<Product> GetByIdAsync(string id)
        {
            return _readRepository.GetSingleAsync(p=>p.Id==Guid.Parse(id));
        }

        [HttpPost("addasync")]
        public async Task<ActionResult> AddAsync([FromBody]CreateProductDto productDto)
        {
            var createdProduct = await _writeRepository.AddAsync(new() { Name = productDto.Name, Price = productDto.Price, Stock = productDto.stock });
            return Created("",createdProduct);
        }

        [HttpPost("updateasync")]
        public async Task<IActionResult> UpdateAsync([FromBody] Product product)
        {
          var updatedProduct=  await _writeRepository.UpdateAsync(product);
            return Created("", updatedProduct);
        }

        [HttpPost("deleteasync")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var DeletedProduct = await _writeRepository.RemoveAsync(id);
            return Ok("Success.");
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFileAsync(IFormFile formFile)
        {
            string uploadPath = Path.Combine("Resource", "product-images");
            var fullPath = Path.Combine(uploadPath, formFile.Name + new Random().NextDouble() + Path.GetExtension(formFile.FileName));
            using (FileStream fs = new(fullPath,FileMode.Create,FileAccess.Write,FileShare.None,1024*1024,useAsync:false))
            {
                await formFile.CopyToAsync(fs);
                await fs.FlushAsync();
            }
            return Ok("Success.");
        }
    }
}
