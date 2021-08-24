using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;

namespace Grupp29.Controllers
{
    public class ForumPostCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ForumPostCategories
        public ActionResult Index()
        {
            return View(db.ForumPostCategories.ToList());
        }
        
        // GET: ForumPostCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPostCategory forumPostCategory = db.ForumPostCategories.Find(id);
            if (forumPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumPostCategory);
        }

        // GET: ForumPostCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumPostCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryName")] ForumPostCategory forumPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.ForumPostCategories.Add(forumPostCategory);
                db.SaveChanges();
                return RedirectToAction("Create", "Forums");
            }

            return View(forumPostCategory);
        }

        // GET: ForumPostCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPostCategory forumPostCategory = db.ForumPostCategories.Find(id);
            if (forumPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumPostCategory);
        }

        // POST: ForumPostCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryName")] ForumPostCategory forumPostCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumPostCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forumPostCategory);
        }

        // GET: ForumPostCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPostCategory forumPostCategory = db.ForumPostCategories.Find(id);
            if (forumPostCategory == null)
            {
                return HttpNotFound();
            }
            return View(forumPostCategory);
        }

        // POST: ForumPostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ForumPostCategory forumPostCategory = db.ForumPostCategories.Find(id);
            db.ForumPostCategories.Remove(forumPostCategory);
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
