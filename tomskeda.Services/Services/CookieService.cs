using Microsoft.AspNetCore.Http;
using Tomskeda.Core.Entities;
using Tomskeda.Services.Interfaces;

namespace Tomskeda.Services.Services
{
    public class CookieService : ICookieService
    {
        public Cookie GetValues( HttpRequest request
            , string day)
        {
            Cookie cookie = new Cookie
            {
                Day = day,
                Ids = request.Cookies["ids" + day],
                Counts = request.Cookies["counts" + day]
            };
            return cookie;
        }
        public void SetCookie(HttpResponse response
            , string key
            , string value)
        {
            response.Cookies.Append(key, value);
        }
        public string GetCookie(HttpRequest request, string key)
        {
            return request.Cookies[key];
        }
    }
}
