using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bdtest.Functions;
using bdtest.Models;
using Microsoft.AspNetCore.Mvc;

namespace bdtest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int day = 0)
        {
            Date date = new Date();
            Products products = new Products();
            ViewBag.Date = date;
            ViewBag.Day = day;
            return View(products);
        }
        public IActionResult GetListFood(int day = 0)
        {
            Date date = new Date();
            Products products = new Products();
            ViewBag.Date = date;
            ViewBag.Day = day;
            return View(products);
        }
        public IActionResult GetMiniBasket(int day = 0)
        {
            Date date = new Date();
            ViewBag.Date = date;
            ViewBag.Day = day;
            return View();
        }
        public IActionResult GetKindsFood(int day = 0)
        {
            Products products = new Products();
            ViewBag.Day = day;
            return View(products);
        }
    }
}

    