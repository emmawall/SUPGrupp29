using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;
using Microsoft.AspNet.Identity;

namespace Grupp29.Controllers
{
    public class MyPageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyPage
        public ActionResult MyPage()
        {
            return View();
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