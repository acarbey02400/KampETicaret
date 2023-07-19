using AutoMapper;
using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.DeleteAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.UpdateAppUser;
using KampETicaret.Application.Features.Queries.AppUserQueries.GetAllAppUser;
using KampETicaret.Application.Features.Queries.AppUserQueries.GetByNameAppUser;
using KampETicaret.Application.RequestParameters;
using KampETicaret.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Infrasturcture.Services.IdentityServices
{
    public class AspNetIdentityUserManager : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;
        public AspNetIdentityUserManager(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AppUser> CreateAsync(AppUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return user;
            }
            throw new Exception(result.Errors.ToString());
        }

        public async Task<bool> DeleteAsync(AppUser user)
        {
            var getUserfindById = await _userManager.FindByIdAsync(user.Id);
            var result = await _userManager.DeleteAsync(getUserfindById);
            if (result.Succeeded)
            {
                return true;
            }
            throw new Exception(result.Errors.ToString());
        }

        public async Task<IList<AppUser>> GetAllAsync(Pagination? pagination)
        {
            var result = await _userManager.Users.ToListAsync();
            var paginationResult = result.Skip(pagination.Page * pagination.Size)
            .Take(pagination.Size)
             .ToList();
            return paginationResult;
        }

        public async Task<AppUser> GetByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<IList<string>> GetRolesAsync(AppUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<AppUser> UpdatAsync(AppUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return user;
            }
            throw new Exception(result.Errors.ToString());
        }
    }
}
