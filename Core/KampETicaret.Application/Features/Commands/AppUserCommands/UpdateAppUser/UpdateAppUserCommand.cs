using AutoMapper;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Commands.AppUserCommands.UpdateAppUser
{
    public class UpdateAppUserCommand : IRequest<UpdateAppUserCommandResponse>
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }

    }
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, UpdateAppUserCommandResponse>
    {
        UserManager<AppUser> _userManager;
        IMapper _mapper;
        public UpdateAppUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UpdateAppUserCommandResponse> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser mappedAppUser = _mapper.Map<AppUser>(request);
            var result = await _userManager.UpdateAsync(mappedAppUser);
            UpdateAppUserCommandDto mappedDto=_mapper.Map<UpdateAppUserCommandDto>(mappedAppUser);
            return new() { Errors=result.Errors, Succeeded=result.Succeeded, UpdateAppUserCommandDto=mappedDto };
        }
    }
    public class UpdateAppUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError>? Errors { get; set; }
        public UpdateAppUserCommandDto? UpdateAppUserCommandDto { get; set; }
    }
    public class UpdateAppUserCommandDto
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
