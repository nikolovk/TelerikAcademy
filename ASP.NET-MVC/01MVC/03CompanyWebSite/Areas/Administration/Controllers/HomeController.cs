using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03CompanyWebSite.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Administration/Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}