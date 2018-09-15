using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uslugi.Domain.Abstract;

namespace Uslugi.WebUI.Controllers
{
    public class UslugiController : Controller
    {
        private IOfferRepository repository;
        public UslugiController(IOfferRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string keyWord)
        {
            if (keyWord == null)
            {
                return View(repository.Offers);
            }else
            {
                return View(repository.Offers
                .Where(o => o.Name == keyWord || o.Category == keyWord));
            }     
        }
    }
}