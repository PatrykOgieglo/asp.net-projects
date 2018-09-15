using myTarantulas.Domain;
using myTarantulas.Domain.Abstract;
using myTarantulas.Domain.Entities;
using myTarantulas.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myTarantulas.WebUI.Controllers
{
    public class BreederController : Controller
    {
        private ITarantulaRepository repositoryTarantulas;
        private IUserRepository repositoryUsers;
        private IOtherTarantulaRepository otherRepository;

        public int PageSize = 7;

        public BreederController(ITarantulaRepository repoTar, IUserRepository repoUser, IOtherTarantulaRepository otherRepo)
        {
            repositoryTarantulas = repoTar;
            repositoryUsers = repoUser;
            otherRepository = otherRepo;
        }

        public ActionResult Index()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var user = repositoryUsers.Users.Where(u => u.Username == Session["uname"].ToString()).FirstOrDefault();
                TarantulaHelper tHelper = new TarantulaHelper();
                int numberOfTarantula = tHelper.NumberOfTarantula(repositoryTarantulas, repositoryUsers, user.Username);
                UserAndTarantulaModel model = new UserAndTarantulaModel
                {
                    UserM = user,
                    NumberOfTarantula = numberOfTarantula
                };

                return View(model);
            }           
        }

        public ActionResult Tarantulas(int page = 1)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var user = repositoryUsers.Users.Where(a => a.Username == Session["uname"].ToString()).FirstOrDefault();
                TarantulaListViewModel model = new TarantulaListViewModel()
                {
                    Tarantulas = repositoryTarantulas.Tarantulas.Where(a => a.UserID == user.UserID).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repositoryTarantulas.Tarantulas.Where(a => a.UserID == user.UserID).Count()
                    }
                };
                return View(model);
            }
        }

        public ActionResult Others(int page = 1)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var user = repositoryUsers.Users.Where(a => a.Username == Session["uname"].ToString()).FirstOrDefault();
                OtherListViewModel model = new OtherListViewModel()
                {
                    OtherTarantulas = otherRepository.OtherTarantulas.Where(a => a.UserID == user.UserID).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = otherRepository.OtherTarantulas.Where(a => a.UserID == user.UserID).Count()
                    }
                };
                return View(model);
            }
        }

        public ActionResult Photos()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Messages()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ForSale()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var user = repositoryUsers.Users.Where(u => u.Username == Session["uname"].ToString()).FirstOrDefault();
                TarantulaAndOther model = new TarantulaAndOther()
                {
                    Tarantulas = repositoryTarantulas.Tarantulas.Where(u => u.UserID == user.UserID),
                    OtherTarantulas = otherRepository.OtherTarantulas.Where(u => u.UserID == user.UserID),
                };

                return View(model);
            }
        }
        
        [HttpPost]
        public ActionResult AddWebOrFacebook(User user)
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                repositoryUsers.AddWebToUser(user);

                return RedirectToAction("Index", "Breeder");
            }
        }

        public ActionResult AddW()
        {
            if (Session["uname"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var user = repositoryUsers.Users.Where(u => u.Username == Session["uname"].ToString()).FirstOrDefault();
                return View(user);
            }
        }
    }
}