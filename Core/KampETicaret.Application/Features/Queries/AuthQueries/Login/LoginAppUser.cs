using KampETicaret.Application.Abstractions.TokenManager;
using KampETicaret.Application.Dtos;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Queries.AuthQueries.Login
{
    public class LoginAppUserQuery : IRequest<LoginAppUserResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }
    public class LoginAppUserHandler : IRequestHandler<LoginAppUserQuery, LoginAppUserResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        public LoginAppUserHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<LoginAppUserResponse> Handle(LoginAppUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (signInResult.Succeeded)
            {
                return new() { Success = signInResult.Succeeded, Token = _tokenHandler.CreateAccessToken(),Message="Giriş yapıldı." };

            }
            return new() { Success = false, Message="Kullanıcı adı veya şifre hatalı" };
           
        }
    }
    public class LoginAppUserResponse
    {
        public string? Message { get; set; }
        public Token? Token { get; set; }
        public bool Success { get; set; }

    }
}
