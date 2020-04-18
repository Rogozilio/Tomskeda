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
        public IActionResult Index()
        {
            Date date = new Date();
            Products products = new Products();
            ViewBag.Date = date;
            return View(products);
        }
    }
}