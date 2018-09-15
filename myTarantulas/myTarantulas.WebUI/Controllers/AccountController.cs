using myTarantulas.Domain.Abstract;
using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myTarantulas.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository repository;

        public AccountController(IUserRepository repoParam)
        {
            repository = repoParam;
        }

        [HttpGet]
        public ViewResult LogIn()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User userObj)
        {
            userObj.Username = repository.Users.Where(a => a.Email == userObj.Email).FirstOrDefault().Username;
            if (ModelState.IsValid)
            {
                var obj = repository.Users.Where(a => a.Email.Equals(userObj.Email) && a.Password.Equals(userObj.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["uname"] = userObj.Username;
                    Session.Timeout = 100;
                    return RedirectToRoute( new { controller = "Home", action = "Index" });
                }
            }

            return View();
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User userObj)
        {
            if (ModelState.IsValid)
            {
                var userN = repository.Users.Where(a => a.Username == userObj.Username).FirstOrDefault();
                if (userN == null)
                {
                    var userNN = repository.Users.Where(a => a.Username == userObj.Username).FirstOrDefault();
                    if (userNN == null)
                    {
                        repository.AddUser(userObj);
                        return RedirectToRoute( new { controller = "Home", action = "Index" });
                    }
                    else
                        return View();
                }
                else
                    return View();                  
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("uname");

            return Redirect("~/Home/Index");
        }
    }
}