using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdtest.Functions;
using System.Net.Http.Headers;
using bdtest.Structs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace bdtest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int day = 0)
        {
            DataSet data = new DataSet();
            data.Products = new Products();
            data.Date = new Date();
            data.Day = data.Date.GetWeekDay()[day];
            return View(data);
        }
        public IActionResult GetListFood(int day = 0)
        {
            DataSet data = new DataSet();
            data.Products = new Products();
            data.Date = new Date();
            data.Day = data.Date.GetWeekDay()[day];
            return View(data);
        }
        public IActionResult GetMiniBasket(int day = 0)
        {
            DataSet data = new DataSet();
            data.Products = new Products();
            data.Date = new Date();
            data.Day = data.Date.GetWeekDay()[day];
            data.CookieId = Request.Cookies["ids" + data.Day];
            data.CookieCount = Request.Cookies["counts" + data.Day];
            ViewBag.a = new int[5] { 1,2,3,4,5 };
            return View(data);
        }
        public IActionResult GetKindsFood(int day = 0)
        {
            DataSet data = new DataSet();
            data.Products = new Products();
            data.Day = new Date().GetWeekDay()[day];
            return View(data);
        }
    }
}

    