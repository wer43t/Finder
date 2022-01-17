using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderCore;

namespace FinderWEB2.Controllers
{
    public class AboutController : Controller
    {
        FinderCoreApp core = new FinderCoreApp();       //Обязатеьно исправить Поле класса не используется (Мясников)
        [HttpGet]
        public IActionResult Index()
        {
            return View(CurrentUser.user);
        }
    }
}
