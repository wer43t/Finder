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
        FinderCoreApp core = new FinderCoreApp();
        [HttpGet]
        public IActionResult Index()
        {
            return View(CurrentUser.user);
        }
    }
}
