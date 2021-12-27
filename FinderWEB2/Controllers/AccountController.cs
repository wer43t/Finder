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
                return RedirectToAction("Index", "Home", core.GetUser(user.email, user.password));
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
            if (core.CreateNewAccount(user))
            {
                TempData["User"] = core.GetUser(user.email, user.password);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid data");

            return View(user);
        }
    }
}
