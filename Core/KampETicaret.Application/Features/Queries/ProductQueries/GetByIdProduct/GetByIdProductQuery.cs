using AutoMapper;
using KampETicaret.Application.Features.Queries.ProductQueries.GetAllProduct;
using KampETicaret.Application.RepositoryService;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQuery:IRequest<GetByIdProductResponse>
    {
        public Guid Id { get; set; }
    }
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
           Product product= await _productReadRepository.GetSingleAsync(p => p.Id == request.Id);
            GetByIdProductDto mappedProduct = _mapper.Map<GetByIdProductDto>(product);
            return new() { GetByIdProductDto = mappedProduct };
        }
    }
    public class GetByIdProductResponse
    {
        public GetByIdProductDto? GetByIdProductDto { get; set; }
    }
    public class GetByIdProductDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
