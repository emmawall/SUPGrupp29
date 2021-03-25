using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;



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
        public ActionResult ShowList()
        {
            var ctx = new ApplicationDbContext();
            var list = new RoomList();
            var user = User.Identity.GetUserId();
            var account = ctx.Users.FirstOrDefault(a => a.Id == user);

            list.listName = account.listName;
            return View(list);

        }
        public ActionResult ShowList(string user)
        {
            var app = new ApplicationDbContext();
            var ctx = db.RoomLists;
            var list = new RoomList();
            var account = app.Users.FirstOrDefault(a => a.Id == user);

            list.listName = account.listName;


          return View("RoomList", list);
        }
    }

}