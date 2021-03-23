using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupp29.Controllers
{
    public class RoomListController : Controller
    {
        // GET: RoomList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateList()
        {
            ViewBag.Message = "Här kan du skapa din personliga lista";

            return View();
        }
    }
}