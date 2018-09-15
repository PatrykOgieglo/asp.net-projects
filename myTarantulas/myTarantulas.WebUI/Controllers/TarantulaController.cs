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
    public class TarantulaController : Controller
    {
        private ITarantulaRepository repository;
        private IUserRepository userRepository;

        public TarantulaController(ITarantulaRepository repo, IUserRepository userRepo)
        {
            userRepository = userRepo;
            repository = repo;
        }

        [HttpGet]
        public ViewResult AddTarantula()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTarantula(Tarantula tarantula)
        {
            if (tarantula != null && ModelState.IsValid)
            {
                var user = userRepository.Users.Where(u => u.Username == Session["uname"].ToString()).FirstOrDefault();
                tarantula.UserID = user.UserID;
                repository.AddTarantula(tarantula);
                return RedirectToAction("Tarantulas", "Breeder");
            }
            else
                return View();           
        }

        public ActionResult Delete(int tarantulaID)
        {
            repository.DeleteTarantula(tarantulaID);
            return RedirectToAction("Tarantulas", "Breeder");
        }

        [HttpGet]
        public ViewResult Edit(int tarantulaID)
        {
            var tarantulaToEdit = repository.Tarantulas.Where(a => a.TarantulaID == tarantulaID).FirstOrDefault();
            return View(tarantulaToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Tarantula tarantula)
        {
            if (ModelState.IsValid)
            {               
                repository.EditTarantula(tarantula);
                return RedirectToAction("Tarantulas", "Breeder");           
            }
            else
                return RedirectToAction("Edit", "Tarantula", new { tarantulaID = tarantula.TarantulaID });
        }

        public ActionResult DeleteFromSellList(int tarantulaID)
        {
            repository.DeleteFromSellList(tarantulaID);
            return RedirectToAction("ForSale", "Breeder");
        }

        
    }
}