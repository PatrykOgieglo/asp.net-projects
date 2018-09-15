using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Uslugi.WebUI.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult Navigation()
        {
            return PartialView();
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}