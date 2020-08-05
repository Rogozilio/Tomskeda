using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Tomskeda.Core.Entities;
using Tomskeda.Services.Interfaces;
using Tomskeda.Services.Services;

namespace Tomskeda.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Input()
        {
            return View();
        }
        public IActionResult Registration(bool IsAccountExist = false)
        {
            return View(IsAccountExist);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if(_userService.IsAccountExist(user))
            {
                return RedirectToAction("Registration", new { IsAccountExist = true });
            }
            else
            {
                _userService.AddUser(user);
                return View();
            }
        }
    }
}