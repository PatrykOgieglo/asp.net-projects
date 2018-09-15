using myTarantulas.Domain;
using myTarantulas.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myTarantulas.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        public static int profileId;
        private IUserRepository repository;
        private ITarantulaRepository tarantulaRepo;
        private IOtherTarantulaRepository otherTarantulaRepo;

        public ProfileController(IUserRepository repo, ITarantulaRepository tRepo, IOtherTarantulaRepository oRepo)
        {
            repository = repo;
            tarantulaRepo = tRepo;
            otherTarantulaRepo = oRepo;
        }

        public ViewResult Index(int profileID)
        {
            profileId = profileID;
            return View(tarantulaRepo.Tarantulas.Where(u => u.UserID == profileId));
        }

        public ActionResult ShowProfile()
        {
            int id = ProfileController.profileId;
            var user = repository.Users.Where(u => u.UserID == id).FirstOrDefault();
            ViewBag.Name = user.Username;
            ViewBag.Social = user.WebOrFb;
            return PartialView();
        }

        public PartialViewResult NavProfile()
        {
            return PartialView();
        }

        public ViewResult Tarantulas()
        {
            return View(tarantulaRepo.Tarantulas.Where(u => u.UserID == profileId));
        }

        public ViewResult OtherTarantulas()
        {
            return View(otherTarantulaRepo.OtherTarantulas.Where(u => u.UserID == profileId));
        }

        public ViewResult ForSell()
        {
            return View(tarantulaRepo.Tarantulas.Where(u => u.Price != null && u.UserID == profileId));
        }
    }
}