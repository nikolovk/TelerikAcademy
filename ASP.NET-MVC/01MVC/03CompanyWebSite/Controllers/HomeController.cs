using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03CompanyWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Company about page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Company contact page.";

            return View();
        }
    }
}