using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdtest.Functions;
using bdtest.Structs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bdtest.Models;

namespace bdtest.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index(int day = 0)
        {
            DataSet data = new DataSet();
            data.Product = new Product();
            data.Date = new Date();
            data.Day = data.Date.GetWeekDay()[day];
            return View(data);
        }
        public IActionResult GetListFood(int day = 0)
        {
            DataSet data = new DataSet();
            data.Product = new Product();
            data.Date = new Date();
            data.Day = data.Date.GetWeekDay()[day];
            return View(data);
        }
        public IActionResult GetMiniBasket(int day = 0)
        {
            DataSet data = new DataSet();
            data.Product = new Product();
            data.Date = new Date();
            data.Day = data.Date.GetWeekDay()[day];
            Response.Cookies.Append("day", data.Day.ToString());
            data.Cookie = new Models.Cookie()
            {
                Ids = Request.Cookies["ids" + data.Day],
                Counts = Request.Cookies["counts" + data.Day]
            };
            return View(data);
        }
        public IActionResult GetKindsFood(int day = 0)
        {
            DataSet data = new DataSet();
            data.Product = new Product();
            data.Day = new Date().GetWeekDay()[day];
            return View(data);
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

    