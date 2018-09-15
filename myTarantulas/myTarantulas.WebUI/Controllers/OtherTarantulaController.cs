using myTarantulas.Domain;
using myTarantulas.Domain.Abstract;
using myTarantulas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myTarantulas.WebUI.Controllers
{
    public class OtherTarantulaController : Controller
    {
        private IOtherTarantulaRepository repository;
        private IUserRepository userRepository;

        public OtherTarantulaController(IOtherTarantulaRepository repo, IUserRepository userRepo)
        {
            userRepository = userRepo;
            repository = repo;
        }

        [HttpGet]
        public ViewResult AddOtherTarantula()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOtherTarantula(OtherTarantulas other)
        {
            if (other != null)
            {
                var user = userRepository.Users.Where(u => u.Username == Session["uname"].ToString()).FirstOrDefault();
                other.UserID = user.UserID;
                repository.AddOtherTarantula(other);
                return RedirectToAction("Others", "Breeder");
            }
            else
                return View();
        }

        public ActionResult Delete(int otherID)
        {
            repository.DeleteOtherTarantula(otherID);
            return RedirectToAction("Others", "Breeder");
        }

        [HttpGet]
        public ViewResult Edit(int otherID)
        {
            var tarantulaToEdit = repository.OtherTarantulas.Where(a => a.OtherTarantulaID == otherID).FirstOrDefault();
            return View(tarantulaToEdit);
        }

        [HttpPost]
        public ActionResult Edit(OtherTarantulas other)
        {
            if (ModelState.IsValid)
            {
                repository.EditOtherTarantula(other);
                return RedirectToAction("Others", "Breeder");
            }
            else
                return RedirectToAction("Edit", "OtherTarantula", new { tarantulaID = other.OtherTarantulaID });
        }

        public ActionResult DeleteFromSellList(int otherID)
        {
            repository.DeleteFromSellList(otherID);
            return RedirectToAction("ForSale", "Breeder");
        }
    }
}