using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Application.Abstractions.TokenManager;
using KampETicaret.Application.Features.Queries.AuthQueries.Login;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Infrasturcture.Services.IdentityServices
{
    public class AspNetIdentityAuthManager : IAuthService
    {
        SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        public AspNetIdentityAuthManager(SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginAppUserResponse> CheckPasswordSignInAsync(AppUser user, string password, bool lockoutOnFailure, IList<string> roles)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (signInResult.Succeeded)
            {
                return new() { Success = signInResult.Succeeded, Token = _tokenHandler.CreateAccessToken(user, roles), Message = "Giriş yapıldı." };

            }
            return new() { Success = false, Message = "Kullanıcı adı veya şifre hatalı" };
        }
    }
}
