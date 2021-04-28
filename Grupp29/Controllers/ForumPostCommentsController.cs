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
    public class ForumPostCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<ForumPostComment> GetComments(int ForumPostId)
        {
            var listOfAllComments = db.ForumPostComments.ToList();
            var listOfMatchingComments = new List<ForumPostComment>();
            foreach (ForumPostComment comment in listOfAllComments)
            {
                if (comment.ForumPostId.Equals(ForumPostId))
                {
                   listOfMatchingComments.Add(comment);
                }
            }
            return listOfMatchingComments;
        }

        [HttpPost]
        public void CreateComment(int ForumPostId, string CommentText)
        {

            ForumPostComment comment = new ForumPostComment();
            comment.Author = User.Identity.Name;
            comment.DateTime = DateTime.Now;
            comment.ForumPostId = ForumPostId;
            comment.CommentText = CommentText;


            db.ForumPostComments.Add(comment);
            db.SaveChanges();
        }

        public bool DoesCommentExist(string CommentText, string Author)
        {
            bool exists = true;
            var listOfallComments = db.ForumPostComments.ToList();
            foreach (ForumPostComment comment in listOfallComments)
            {
                if (comment.CommentText.Equals(CommentText) && comment.Author.Equals(Author))
                {
                    exists = false;
                }
            }

            return exists;
        }





        // GET: ForumPostComments
        public ActionResult Index()
        {
            return View(db.ForumPostComments.ToList());
        }

        // GET: ForumPostComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPostComment forumPostComment = db.ForumPostComments.Find(id);
            if (forumPostComment == null)
            {
                return HttpNotFound();
            }
            return View(forumPostComment);
        }

        // GET: ForumPostComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumPostComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author,CommentText,DateTime,ForumPostId")] ForumPostComment forumPostComment)
        {
            if (ModelState.IsValid)
            {
                db.ForumPostComments.Add(forumPostComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forumPostComment);
        }

        // GET: ForumPostComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPostComment forumPostComment = db.ForumPostComments.Find(id);
            if (forumPostComment == null)
            {
                return HttpNotFound();
            }
            return View(forumPostComment);
        }

        // POST: ForumPostComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author,CommentText,DateTime,ForumPostId")] ForumPostComment forumPostComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumPostComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forumPostComment);
        }

        // GET: ForumPostComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumPostComment forumPostComment = db.ForumPostComments.Find(id);
            if (forumPostComment == null)
            {
                return HttpNotFound();
            }
            return View(forumPostComment);
        }

        // POST: ForumPostComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumPostComment forumPostComment = db.ForumPostComments.Find(id);
            db.ForumPostComments.Remove(forumPostComment);
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
