using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinderWEB2.Controllers
{
    public class AboutContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
