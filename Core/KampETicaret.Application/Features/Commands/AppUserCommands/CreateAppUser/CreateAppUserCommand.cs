using AutoMapper;
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
        readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser mappedAppUser = _mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(mappedAppUser, request.Password);
            if (!result.Succeeded)
            {
                return new() { Succeeded = result.Succeeded, Errors = result.Errors };
            }
            var createdUser =await _userManager.FindByEmailAsync(mappedAppUser.Email);
            var mappedDto = _mapper.Map<CreateAppUserCommandDto>(createdUser);            
            return new() { Succeeded = result.Succeeded, CreateAppUserCommandDto = mappedDto };
        }
    }
    public class CreateAppUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError>? Errors { get; set; }
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
