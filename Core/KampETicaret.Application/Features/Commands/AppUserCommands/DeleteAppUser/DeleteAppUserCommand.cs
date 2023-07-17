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
        public string? Email { get; set; }
    }
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, DeleteAppUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public DeleteAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<DeleteAppUserCommandResponse> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {

            var resultFindByEmail = await _userManager.FindByEmailAsync(request.Email);
            var result = await _userManager.DeleteAsync(resultFindByEmail);
            return new() { Errors = result.Errors, Succeeded = result.Succeeded };

        }
    }
    public class DeleteAppUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError>? Errors { get; set; }
    }
}
