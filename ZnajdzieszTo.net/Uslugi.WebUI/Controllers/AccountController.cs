using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uslugi.Domain.Abstract;
using Uslugi.Domain.Entities;
using Uslugi.WebUI.Context;

namespace Uslugi.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (EfDbContext db = new EfDbContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }

            return View();  
        }

        public ViewResult ForgotPass()
        {
            return View();
        }
    }
}
