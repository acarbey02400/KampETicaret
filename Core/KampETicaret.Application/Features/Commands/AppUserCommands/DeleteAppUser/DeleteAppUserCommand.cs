using AutoMapper;
using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Commands.AppUserCommands.DeleteAppUser
{
    public class DeleteAppUserCommand : IRequest<DeleteAppUserCommandResponse>
    {
        public string? Id { get; set; }
    }
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, DeleteAppUserCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DeleteAppUserCommandHandler(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<DeleteAppUserCommandResponse> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {

            var mappedAppUser = _mapper.Map<AppUser>(request);

            var deletedUser= await _userService.DeleteAsync(mappedAppUser);
            if (deletedUser)
            {
                return new() { Success = true };
            }
            return new() {  Success = false };
        }
    }
    public class DeleteAppUserCommandResponse
    {
        public bool Success { get; set; }
    }
}
