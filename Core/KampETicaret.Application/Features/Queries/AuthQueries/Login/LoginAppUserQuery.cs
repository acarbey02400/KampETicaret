﻿using AutoMapper;
using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Application.Abstractions.TokenManager;
using KampETicaret.Application.Dtos;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        readonly IUserService _userManager;
        readonly IAuthService _loginService;
       
        private readonly IMapper _mapper;
        public LoginAppUserHandler(IUserService userManager, IAuthService loginService, IMapper mapper)
        {
            _userManager = userManager;
            _loginService = loginService;
            _mapper = mapper;
        }
        public async Task<LoginAppUserResponse> Handle(LoginAppUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getByNameUserResponse = await _userManager.GetByNameAsync(request.UserName);
                var role = await _userManager.GetRolesAsync(getByNameUserResponse);
                var response = await _loginService.CheckPasswordSignInAsync(getByNameUserResponse, request.Password, false, role);
                if (response.Success)
                {
                    //Login işlemi gerçekleştiğinde refresh tokenı kullanıcıya gönderiyoruz.
                    getByNameUserResponse.RefreshToken = response.Token.RefreshToken;
                    getByNameUserResponse.RefreshTokenEndDate = response.Token.Expiration.AddHours(3);
                    await _userManager.UpdateAsync(getByNameUserResponse);
                    return response;
                }
            }
            catch (Exception ex)
            {

                return new() { Message = ex.Message, Success = false };
            }
            return new() {Success=false };
           
           
        }
    }
    public class LoginAppUserResponse
    {
        public string? Message { get; set; }
        public Token? Token { get; set; }
        public bool Success { get; set; }

    }
}
