using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Tomskeda.Core.Entities;
using Tomskeda.Services.Interfaces;
using Tomskeda.Services.Services;
using Tomskeda.Services.Structs;
using Yandex.Checkout.V3;

namespace Tomskeda.Controllers
{
    public class OrderController : Controller
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
        private readonly IOrderService _orderService;
        /// <summary>
        /// 
        /// </summary>
        private readonly ICookieService _cookieService;
        /// <summary>
        /// 
        /// </summary>
        private DataSet _data;
        public OrderController(IProductService productsService
            , IDateService dateSerivce
            ,IOrderService orderService
            ,ICookieService cookieService)
        {
            _productsService = productsService;
            _dateService = dateSerivce;
            _orderService = orderService;
            _cookieService = cookieService;
            _data = new DataSet
            {
                Product = _productsService,
                Date = _dateService
            };
        }
        public IActionResult OrderSend()
        {
            _data.Day = int.Parse(_cookieService.GetCookie(Request, "day"));
            _data.Cookie = _cookieService
                .GetValues(Request, _data.Day.ToString());
            return View(_data);
        }

        public IActionResult OrderFinish()
        {
            _data.Day = int.Parse(_cookieService.GetCookie(Request, "day"));
            _data.Cookie = _cookieService
                .GetValues(Request, _data.Day.ToString());
            return View(_data);
        }

        [HttpPost]
        public IActionResult OrderSend(Order order)
        {
            if(!ModelState.IsValid)
            {
                _data.Day = int.Parse(_cookieService.GetCookie(Request, "day"));
                _data.Cookie = _cookieService
                    .GetValues(Request, _data.Day.ToString());
                return View(Url.Action("OrderSend","Order")
                    , _data);
            }
            if(order.Pay == "2")
            {
                string url = _orderService.PaymentYandex(order, 
                    _productsService.GetPriceProducts(_data.Cookie.Ids, _data.Cookie.Counts));
                Response.Redirect(url);
            }
            //_orderService.SendOrder(order, 
                //cookie, _productsService.GetPriceProducts(cookie.Ids, cookie.Counts, false));
            return RedirectToAction("OrderFinish");
        }
    }
}