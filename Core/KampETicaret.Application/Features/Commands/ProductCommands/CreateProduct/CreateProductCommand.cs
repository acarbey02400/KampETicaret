using AutoMapper;
using KampETicaret.Application.RepositoryService;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommand:IRequest<CreateProductCommandResponse>
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var CreatedProduct = await _writeRepository.AddAsync(product);
            var mappedProduct=_mapper.Map<CreateProductCommandDto>(CreatedProduct);
            return new() { CreateProductCommandDto = mappedProduct };
        }
    }
    public class CreateProductCommandResponse
    {
        public CreateProductCommandDto? CreateProductCommandDto { get; set; }
    }
    public class CreateProductCommandDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
