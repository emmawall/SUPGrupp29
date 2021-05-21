using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;

namespace Grupp29.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Role
//        public ActionResult Index()
//        {
//            if (User.Identity.IsAuthenticated)
//            {


//                if (!isAdminUser())
//                {
//                    return RedirectToAction("Index", "Home");
//    }
//}
//            else
//            {
//                return RedirectToAction("Index", "Home");
//            }

//            var Roles = context.Roles.ToList();
//            return View(Roles);
//        }
    }
}