using KampETicaret.WebForms.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace KampETicaret.WebForms.Services.Concrete
{
    public class WebRequestService:IWebRequestService
    {
      
        public WebRequest Create(string uri)
        {
            return WebRequest.Create(uri);
        }
        public WebRequest Create(Uri uri)
        {
            return WebRequest.Create(uri);
        }
    }
}