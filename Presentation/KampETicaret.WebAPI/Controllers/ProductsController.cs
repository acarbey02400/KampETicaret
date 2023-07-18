using KampETicaret.Application.Dtos;
using KampETicaret.Application.Features.Commands.ProductCommands.CreateProduct;
using KampETicaret.Application.Features.Commands.ProductCommands.DeleteProduct;
using KampETicaret.Application.Features.Commands.ProductCommands.UpdateProduct;
using KampETicaret.Application.Features.Queries.ProductQueries.GetAllProduct;
using KampETicaret.Application.Features.Queries.ProductQueries.GetByIdProduct;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Application.RequestParameters;
using KampETicaret.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace KampETicaret.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin",Roles ="admin")]
    public class ProductsController : BaseController
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IProductReadRepository _readRepository;

        public ProductsController(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        [HttpGet("getallasync")]
        public async Task<ActionResult> GetAllAsync([FromQuery]GetAllProductQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyidasync")]
        public async Task<ActionResult> GetByIdAsync([FromQuery]GetByIdProductQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("addasync")]
        public async Task<ActionResult> AddAsync([FromBody]CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Created("",result);
        }

        [HttpPost("updateasync")]
        public async Task<ActionResult> UpdateAsync([FromBody]UpdateProductCommand command)
        {
            var updatedProduct = await Mediator.Send(command);
            return Created("", updatedProduct);
        }

        [HttpPost("deleteasync")]
        public async Task<ActionResult> DeleteAsync([FromBody] DeleteProductCommand command)
        {
            var DeletedProduct = await Mediator.Send(command);
            return Ok(DeletedProduct);
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
