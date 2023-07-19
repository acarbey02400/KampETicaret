using KampETicaret.Application.Features.Queries.AuthQueries.Login;
using KampETicaret.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices
{
    public interface IAuthService
    {
        Task<LoginAppUserResponse> CheckPasswordSignInAsync(AppUser user, string password, bool lockoutOnFailure,IList<string> roles);
    }
}
