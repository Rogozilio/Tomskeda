using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tomskeda.Core.Entities;
using Tomskeda.Services.Interfaces;
using Tomskeda.Services.Structs;

namespace Tomskeda.Controllers
{
    public class IndexController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IProductService _productsService;
        /// <summary>
        /// 
        /// </summary>
        private readonly IDateService _dateService;
        /// <summary>
        /// 
        /// </summary>
        private readonly ICookieService _cookieService;
        /// <summary>
        /// 
        /// </summary>
        private DataSet _data;
        public IndexController(IProductService productsService
            , IDateService dateSerivce
            , ICookieService cookieService)
        {
            _productsService = productsService;
            _dateService = dateSerivce;
            _cookieService = cookieService;
            _data = new DataSet
            {
                Product = _productsService,
                Date = _dateService
            };
        }
        public IActionResult Index(int day = 0)
        {
            _data.Day = _data.Date.GetWeekDay()[day];
            return View(_data);
        }
        public IActionResult GetListFood(int day = 0)
        {
            _data.Day = _data.Date.GetWeekDay()[day];
            return View(_data);
        }
        public IActionResult GetMiniBasket(int day = 0)
        {
            _data.Day = _data.Date.GetWeekDay()[day];
            _cookieService.SetCookie(Response,"day"
                , _data.Day.ToString());
            _data.Cookie = _cookieService.GetValues(Request
                , _data.Day.ToString());
            return View(_data);
        }
        public IActionResult GetKindsFood(int day = 0)
        {
            _data.Day = _data.Date.GetWeekDay()[day];
            return View(_data);
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Delivery()
        {
            return View();
        }
    }
}

    