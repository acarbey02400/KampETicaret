using KampETicaret.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Abstractions.TokenManager
{
    public interface ITokenHandler
    {
       Token CreateAccessToken();
    }
}
