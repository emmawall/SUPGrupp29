using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupp29.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult MyPage()
		{
			ViewBag.Message = "Välkommen till din personliga sida";

			return View();
		}

        //public ActionResult CreateList()
        //{
        //    ViewBag.Message = "Här kan du skapa din personliga lista";

        //    return View();
        //}
    }
}