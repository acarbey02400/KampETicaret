using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KampETicaret.WebForms.Auth.JWT
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}