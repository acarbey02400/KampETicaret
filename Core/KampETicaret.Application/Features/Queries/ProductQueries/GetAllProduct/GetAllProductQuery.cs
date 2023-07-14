using AutoMapper;
using KampETicaret.Application.RepositoryService;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Application.RequestParameters;
using KampETicaret.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Queries.ProductQueries.GetAllProduct
{
    public class GetAllProductQuery:IRequest<GetAllProductQueryResponse>
    {
        public Pagination? Pagination { get; set; }
    }
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;
        //iş kuralları da eklenecek
        public GetAllProductQueryHandler(IProductReadRepository productReadRepository,IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
          var result = await _productReadRepository.GetAllAsync();
          var paginationResult =  result.Skip(request.Pagination.Page * request.Pagination.Size)
               .Take(request.Pagination.Size)
              .ToList();
           var response = _mapper.Map<IList<GetAllProductQueryDto>>(paginationResult);
            return new() { Items=response};
            
        }
    }
    public class GetAllProductQueryResponse
    {
       public IList<GetAllProductQueryDto>? Items { get; set; }
    }
    public class GetAllProductQueryDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
