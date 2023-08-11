using AutoMapper;
using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Application.Abstractions.TokenManager;
using KampETicaret.Application.Dtos;
using KampETicaret.Application.Features.Queries.AuthQueries.Login;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Queries.AuthQueries.RefreshTokenLogin
{
    public class RefreshTokenLoginAppUserQuery : IRequest<RefreshTokenLoginAppUserResponse>
    {
        public string? RefreshToken { get; set; }

    }
    public class RefreshTokenLoginAppUserQueryHandler : IRequestHandler<RefreshTokenLoginAppUserQuery, RefreshTokenLoginAppUserResponse>
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;
        public RefreshTokenLoginAppUserQueryHandler(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }
        public async Task<RefreshTokenLoginAppUserResponse> Handle(RefreshTokenLoginAppUserQuery request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userService.GetByRefreshToken(request.RefreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var role = await _userService.GetRolesAsync(user);
                var token = _tokenHandler.CreateAccessToken(user, role);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddHours(3);
                await _userService.UpdateAsync(user);
                return new() { Token = token, Success = true };
            }
            return new() { Success = false, Message="Oturum süresi dolmuştur." };
        }
    }
    public class RefreshTokenLoginAppUserResponse
    {
        public string? Message { get; set; }
        public Token? Token { get; set; }
        public bool Success { get; set; }

    }
}
