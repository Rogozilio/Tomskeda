using System;
using System.Security.Cryptography;
using System.Text;
using bdtest.Models;
using Microsoft.AspNetCore.Mvc;

namespace bdtest.Controllers
{
    public class AccountController : Controller
    {

        public AccountController()
        {

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
            if(user.IsAccountExist())
            {
                return RedirectToAction("Registration", new { IsAccountExist = true });
            }
            else
            {
                user.AddUser();
                return View();
            }
            
        }
    }
}