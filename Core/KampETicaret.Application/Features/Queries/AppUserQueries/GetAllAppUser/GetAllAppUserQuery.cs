using AutoMapper;
using FluentValidation;
using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
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
       private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAllAppUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper=mapper;
        }
        public async Task<GetAllAppUserQueryResponse> Handle(GetAllAppUserQuery request, CancellationToken cancellationToken)
        {
            if (request.Pagination == null) request.Pagination = new();
            var users= await _userService.GetAllAsync(request.Pagination);
            var response = _mapper.Map<IList<GetAllAppUserQueryDto>>(users);
            return new() { GetAllAppUserQueryDto = response, Success = true };
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
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
    
}
