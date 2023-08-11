using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public AppUser():base()
        {
            Id = Guid.NewGuid().ToString();
        }
        public AppUser(string fullName,string id):this()
        {
            FullName = fullName;
            Id = id;
        }
        public string? FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

    }
}
