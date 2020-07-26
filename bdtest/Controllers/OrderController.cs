using System;
using System.Collections.Generic;
using System.Linq;
using bdtest.Functions;
using bdtest.Models;
using bdtest.Structs;
using Microsoft.AspNetCore.Mvc;
using Yandex.Checkout.V3;

namespace bdtest.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult OrderSend()
        {
            DataSet data = new DataSet();
            data.Date = new Date();
            data.Product = new Product();
            data.Day = int.Parse(Request.Cookies["day"]);
            data.Cookie = new Models.Cookie()
            {
                Day = Request.Cookies["day"],
                Ids = Request.Cookies["ids" + data.Day],
                Counts = Request.Cookies["counts" + data.Day]
            };
            return View(data);
        }

        public IActionResult OrderFinish()
        {
            DataSet data = new DataSet();
            data.Date = new Date();
            data.Product = new Product();
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
        public IActionResult OrderSend(Order order)
        {
            
            Cookie cookie = new Cookie();
            cookie.Day = Request.Cookies["day"];
            cookie.Ids = Request.Cookies["ids" + cookie.Day];
            cookie.Counts = Request.Cookies["counts" + cookie.Day];
            if(order.Pay == "2")
            {
                string url = order.PaymentYandex(new Product().
                    GetPriceProducts(cookie.Ids, cookie.Counts));
                Response.Redirect(url);
            }
            //order.SendOrder(cookie);
            return RedirectToAction("OrderFinish");
        }
    }
}