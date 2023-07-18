using KampETicaret.Application.Dtos;
using KampETicaret.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Abstractions.TokenManager
{
    public interface ITokenHandler
    {
       Token CreateAccessToken(AppUser user, IList<string> roles);
    }
}
