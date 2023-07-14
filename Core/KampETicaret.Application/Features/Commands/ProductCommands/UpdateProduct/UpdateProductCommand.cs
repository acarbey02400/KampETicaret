using AutoMapper;
using KampETicaret.Application.Features.Commands.ProductCommands.CreateProduct;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var UpdatedProduct = await _writeRepository.UpdateAsync(product);
            var mappedProduct = _mapper.Map<UpdateProductCommandDto>(UpdatedProduct);
            return new() { UpdateProductCommandDto = mappedProduct };
        }
    }
    public class UpdateProductCommandResponse
    {
        public UpdateProductCommandDto? UpdateProductCommandDto { get; set; }
    }
    public class UpdateProductCommandDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
