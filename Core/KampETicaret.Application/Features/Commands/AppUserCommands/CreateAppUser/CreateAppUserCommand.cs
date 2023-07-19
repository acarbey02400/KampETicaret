using AutoMapper;
using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Application.Features.Commands.ProductCommands.CreateProduct;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser
{
    public class CreateAppUserCommand : IRequest<CreateAppUserCommandResponse>
    {
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreateAppUserCommandResponse>
    {
        readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser mappedAppUser = _mapper.Map<AppUser>(request);
            var createdUser= await _userService.CreateAsync(mappedAppUser,request.Password);
           
            var mappedDto = _mapper.Map<CreateAppUserCommandDto>(createdUser);
            return new() { Succeeded = true, CreateAppUserCommandDto = mappedDto };
        }
    }
    public class CreateAppUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public CreateAppUserCommandDto? CreateAppUserCommandDto { get; set; }
    }
    public class CreateAppUserCommandDto
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
