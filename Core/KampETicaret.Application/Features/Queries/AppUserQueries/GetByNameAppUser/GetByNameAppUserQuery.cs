using AutoMapper;
using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Queries.AppUserQueries.GetByNameAppUser
{
    public class GetByNameAppUserQuery : IRequest<GetByNameAppUserQueryResponse>
    {
        public string? UserName { get; set; }
    }
    public class GetByNameAppUserQueryHandler : IRequestHandler<GetByNameAppUserQuery, GetByNameAppUserQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetByNameAppUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<GetByNameAppUserQueryResponse> Handle(GetByNameAppUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByNameAsync(request.UserName);
            var mappedDto = _mapper.Map<GetByNameAppUserQueryDto>(user);
            return new() { GetByNameAppUserQueryDto = mappedDto, Success = true };
        }
    }
    public class GetByNameAppUserQueryResponse
    {
        public bool Success { get; set; }
       public GetByNameAppUserQueryDto? GetByNameAppUserQueryDto { get; set; }
    }
    public class GetByNameAppUserQueryDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
    }
}
