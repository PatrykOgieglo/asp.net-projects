using myTarantulas.Domain.Abstract;
using myTarantulas.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myTarantulas.WebUI.Controllers
{
    public class SearchController : Controller
    {
        private IUserRepository userRepository;

        public SearchController(IUserRepository repo)
        {
            userRepository = repo;
        }

        public ViewResult Index(string searchInput)
        {
            if (searchInput == null)
            {
                return View(userRepository.Users);
            }
            else
            {
                string searchToSmaller = searchInput.ToLower();
                return View(userRepository.Users.Where(u => u.Username.ToLower().Contains(searchToSmaller) || searchInput == null).OrderBy(u => u.Username).Take(8).ToList());
            }

        }

        public ViewResult SearchBox()
        {
            return View();
        }    
    }
}
