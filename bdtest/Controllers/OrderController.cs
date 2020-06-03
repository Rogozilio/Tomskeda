using System;
using System.Collections.Generic;
using System.Linq;
using bdtest.Functions;
using bdtest.Models;
using bdtest.Structs;
using Microsoft.AspNetCore.Mvc;

namespace bdtest.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult OrderSend()
        {
            DataSet data = new DataSet();
            data.Date = new Date();
            data.Products = new Products();
            data.Day = int.Parse(Request.Cookies["day"]);
            data.Cookie = new Models.Cookie()
            {
                Day = Request.Cookies["day"],
                Ids = Request.Cookies["ids" + data.Day],
                Counts = Request.Cookies["counts" + data.Day]
            };
            return View(data);
        }

        [HttpPost]
        public string OrderSend(Order order)
        {
            Cookie cookie = new Cookie();
            cookie.Day = Request.Cookies["day"];
            cookie.Ids = Request.Cookies["ids" + cookie.Day];
            cookie.Counts = Request.Cookies["counts" + cookie.Day];
            order.SendOrder(cookie);
            return "lox";
        }
    }
}