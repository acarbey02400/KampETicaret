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

namespace KampETicaret.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
       
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var deletedProduct = await _writeRepository.RemoveAsync(product);
            return new() { isDeleted = deletedProduct };
        }
    }
    public class DeleteProductCommandResponse
    {
        public bool isDeleted { get; set; }
    }
}
