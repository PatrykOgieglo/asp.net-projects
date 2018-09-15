using myTarantulas.Domain;
using myTarantulas.Domain.Abstract;
using myTarantulas.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myTarantulas.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repository;
        private ITarantulaRepository tarantulaRepository;
        private IOtherTarantulaRepository otherRepository;

        public HomeController(IUserRepository repo, ITarantulaRepository tRepo, IOtherTarantulaRepository oRepo)
        {
            repository = repo;
            tarantulaRepository = tRepo;
            otherRepository = oRepo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public PartialViewResult NaviagationBar()
        {
            return PartialView();
        }

        public PartialViewResult SomethingWillBeHere()
        {
            HomeModel model = new HomeModel
            {
                Users = repository.Users,
                Tarantula = tarantulaRepository.Tarantulas,
                Other = otherRepository.OtherTarantulas
            };
            return PartialView(model);
        }

        public PartialViewResult NaviagationBarIfLogin()
        {
            return PartialView();
        }
    }
}