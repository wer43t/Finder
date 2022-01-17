using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderCore;

namespace FinderWEB2.Controllers
{
    public class AccountController : Controller
    {

        FinderCoreApp core = new FinderCoreApp();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {

            if (core.UserAuth(user))
            {
                if (!core.CheckUserInfo())
                    return RedirectToAction("UpdateAbout", "Account");
                else
                    return RedirectToAction("Index", "About");
            }
            ModelState.AddModelError("", "Invalid login or password");
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            user.Country_ID = Convert.ToInt32(Request.Form["Country"]);
            user.Username = "unknown";
            if (core.CreateNewAccount(user))
            {
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Invalid data");

            return View(user);
        }

        [HttpGet]
        public IActionResult UpdateAbout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAbout(User_Info UserInfo)
        {
            UserInfo.Zodiac_ID = Convert.ToInt32(Request.Form["Zodiac_ID"]);
            core.CreateNewUserInfo(UserInfo);
            return RedirectToAction("Index", "About");      //Желательно исправить Закомментированные строки кода (Мясников)
            //if (core.CreateNewAccount(user))
            //{
            //    return RedirectToAction("Index", "Home", core.GetUser(user.email, user.password));
            //}
        }
    }
}
