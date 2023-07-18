using AutoMapper;
using KampETicaret.Application.RequestParameters;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Queries.AppUserQueries.GetAllAppUser
{
    public class GetAllAppUserQuery:IRequest<GetAllAppUserQueryResponse>
    {
        public Pagination? Pagination { get; set; }
    }
    public class GetAllAppUserQueryHandler : IRequestHandler<GetAllAppUserQuery, GetAllAppUserQueryResponse>
    {
        readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public GetAllAppUserQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager=userManager;
            _mapper=mapper;
        }
        public async Task<GetAllAppUserQueryResponse> Handle(GetAllAppUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _userManager.Users.ToListAsync();
            var paginationResult = result.Skip(request.Pagination.Page * request.Pagination.Size)
              .Take(request.Pagination.Size)
             .ToList();
            var response = _mapper.Map<IList<GetAllAppUserQueryDto>>(paginationResult);
            return new() { GetAllAppUserQueryDto = response, Success=true};
        }
    }
    public class GetAllAppUserQueryResponse
    {
        public bool Success { get; set; }
        public IList<GetAllAppUserQueryDto>? GetAllAppUserQueryDto { get; set; }
    }
    public class GetAllAppUserQueryDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
