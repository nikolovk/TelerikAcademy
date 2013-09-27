using _02BitCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02BitCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string baseName = "bit - b", int multiplayer = 1024, double baseNumber = 1)
        {
            Units model = new Units();
            model.LoadUnits(baseName, multiplayer,baseNumber);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}