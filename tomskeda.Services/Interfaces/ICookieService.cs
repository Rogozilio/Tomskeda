using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Tomskeda.Core.Entities;
using Tomskeda.Services.Services;

namespace Tomskeda.Services.Interfaces
{
    public interface ICookieService
    {
        Cookie GetValues(HttpRequest request, string day);
        void SetCookie(HttpResponse response, string key, string value);
        string GetCookie(HttpRequest request, string key);
    }
}
