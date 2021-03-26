using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;
using System.Data.Entity;




namespace Grupp29.Controllers
{
    public class RoomListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateList([Bind(Include = "listName")] RoomList roomList)
        {
            if (ModelState.IsValid)
            {
                db.RoomLists.Add(roomList);
                db.SaveChanges();
                return RedirectToAction("MyPage", "MyPage");
            }

            return View(roomList);
        }
       
    }

}