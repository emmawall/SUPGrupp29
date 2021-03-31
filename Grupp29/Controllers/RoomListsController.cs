﻿using System;
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
            var ctx = new ApplicationDbContext();
            var user = User.Identity.GetUserId();
            var account = ctx.Users.FirstOrDefault(a => a.Id == user);
            var userid = db.Users.Single(i => i.Id == user);
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
            return View();
        }

        // POST: RoomLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,listName")] RoomList roomList)
        {
            if (ModelState.IsValid)
            {
                db.RoomLists.Add(roomList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomList);
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
        public ActionResult Edit([Bind(Include = "id,listName")] RoomList roomList)
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
            return RedirectToAction("Index");
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
