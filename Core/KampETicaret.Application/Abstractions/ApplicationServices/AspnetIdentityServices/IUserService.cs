using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.DeleteAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.UpdateAppUser;
using KampETicaret.Application.Features.Queries.AppUserQueries.GetAllAppUser;
using KampETicaret.Application.Features.Queries.AppUserQueries.GetByNameAppUser;
using KampETicaret.Application.RequestParameters;
using KampETicaret.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices
{
    public interface IUserService
    {
        Task<AppUser> CreateAsync(AppUser user,string password);
        Task<bool> DeleteAsync(AppUser user);
        Task<AppUser> UpdateAsync(AppUser user);
        Task<IList<AppUser>> GetAllAsync(Pagination? pagination);
        Task<AppUser> GetByNameAsync(string name);
        Task<IList<string>> GetRolesAsync(AppUser user);
        Task<AppUser> GetByRefreshToken(string refreshToken);
    }
}
