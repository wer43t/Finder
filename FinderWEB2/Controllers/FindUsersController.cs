using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderCore;

namespace FinderWEB2.Controllers
{
    public class FindUsersController : Controller
    {
        FinderCoreApp core = new FinderCoreApp();
        public IActionResult Index()
        {
            var user = core.GetOneUser();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("End", "FindUsers");
        }

        [HttpPost]
        public ActionResult SetLike(User likedUser)
        {
            core.AddLikes(likedUser);
            var user = core.GetOneUser();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("End", "FindUsers");
        }

        public ActionResult SetDislike()
        {
            var user = core.GetOneUser();
            if (user != null)
            {
                return View(user);
            }
            return RedirectToAction("End", "FindUsers");
        }

        public ActionResult End()
        {
            return View();
        }
        public ActionResult Details(int id)     //Обязательно исправить Неиспользуемый параметр id (Мясников)
        {
            return View();
        }

        // GET: FindUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FindUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FindUserController/Edit/5
        public ActionResult Edit(int id)     //Обязательно исправить Неиспользуемый параметр id (Мясников)
        {
            return View();
        }

        // POST: FindUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FindUserController/Delete/5
        public ActionResult Delete(int id)     //Обязательно исправить Неиспользуемый параметр id (Мясников)
        {
            return View();
        }

        // POST: FindUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
