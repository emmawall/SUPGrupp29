using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;
using Microsoft.AspNet.Identity;

namespace Grupp29.Controllers
{
    public class RoomListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoomLists
        public ActionResult Index()
        {
			return View(db.RoomLists.ToList());
		}

		// GET: RoomLists/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomList roomList = db.RoomLists.Find(id);
            if (roomList == null)
            {
                return HttpNotFound();
            }
            return View(roomList);
        }

        // GET: RoomLists/Create
        public ActionResult Create()
        {
            var listContent = db.PlantLists.ToList();
            List<string> plantContentList = new List<string>();
            foreach (PlantList ct in listContent)
            {
                plantContentList.Add(ct.PlantName);
            }
            ViewBag.PlantContentList = plantContentList;

            return View();
            //return View();
        }

        // POST: RoomLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,listName,ListCreator,PlantContent")] RoomList roomList)
        {
            //if (ModelState.IsValid)

                var listContent = db.PlantLists.ToList();
            List<string> plantContentList = new List<string>();
            foreach (PlantList ct in listContent)
            {
                plantContentList.Add(ct.PlantName);
            }
            ViewBag.PlantContentList = plantContentList;

            roomList.ListCreator = User.Identity.Name;
            {
                db.RoomLists.Add(roomList);
                db.SaveChanges();
                return RedirectToAction("MyPage", "MyPage");
            }
        }

        // GET: RoomLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomList roomList = db.RoomLists.Find(id);
            if (roomList == null)
            {
                return HttpNotFound();
            }
            return View(roomList);
        }

        // POST: RoomLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,listName,ListCreator,PlantContent")] RoomList roomList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomList);
        }

        // GET: RoomLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomList roomList = db.RoomLists.Find(id);
            if (roomList == null)
            {
                return HttpNotFound();
            }
            return View(roomList);
        }

        // POST: RoomLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomList roomList = db.RoomLists.Find(id);
            db.RoomLists.Remove(roomList);
            db.SaveChanges();
            return RedirectToAction("MyPage", "MyPage");
        }

        public List<RoomList> GetRoomListsFromCreator(string creator)
        {

            ApplicationDbContext dbContext = new ApplicationDbContext();
            var listOfMatchingLists = new List<RoomList>();
            var listOfAllLists = dbContext.RoomLists.ToList();

            foreach (RoomList roomList in listOfAllLists)
            {
                if (roomList.ListCreator.Equals(creator))
                {
                    listOfMatchingLists.Add(roomList);
                }

            }
            return listOfMatchingLists;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
