using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;
using Microsoft.AspNet.Identity;

namespace Grupp29.Controllers
{
    public class ForumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Forums
        public static string SelectedFilter { get; set; }

        [HttpPost]
        public ActionResult SetFilter(String filter)
        {
            SelectedFilter = filter;
            return RedirectToAction("Index");
        }

        public ForumsController()
        {
        }

        public static Forum GetPostFromId(int id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            return dbContext.Fora.Find(id);
        }

        //public static string GetProfilePictureFromUsername(string userName)
        //{
        //    string image = "";
        //    ApplicationDbContext dbContext = new ApplicationDbContext();
        //    foreach (ApplicationUser user in dbContext.Users.ToList())
        //    {

        //        if (user.UserName.Equals(userName))
        //        {
        //            image = user.Img;
        //        }
        //    }
        //    return image;

        //}

        public static string GetNameFromUsername(string userName)
        {
            string name = "";
            string displayName = "";
        

            ApplicationDbContext dbContext = new ApplicationDbContext();
            foreach (ApplicationUser user in dbContext.Users.ToList())
            {

                if (user.UserName.Equals(userName))
                {
                    displayName = user.DisplayName;
                    name = displayName;
              
                }
            }
            return name;

        }

        [HttpPost]
        public List<String> GetCategories()
        {
            List<String> namesOfCategory = new List<string>();
            foreach (ForumPostCategory Category in db.ForumPostCategories.ToList())
            {
                namesOfCategory.Add(Category.CategoryName);
            }
            return namesOfCategory;
        }

        public static string GetDateFromDateTime(DateTime DateTime)
        {

            string year = DateTime.Year.ToString();
            string month = DateTime.Month.ToString();
            string day = DateTime.Day.ToString();
            string day2 = DateTime.DayOfWeek.ToString();
            string monthInText = "";
            string dayinText = "";

            switch (DateTime.Month)
            {
                case 1:
                    monthInText = "januari";
                    break;
                case 2:
                    monthInText = "februari";
                    break;
                case 3:
                    monthInText = "mars";
                    break;
                case 4:
                    monthInText = "april";
                    break;
                case 5:
                    monthInText = "maj";
                    break;
                case 6:
                    monthInText = "juni";
                    break;
                case 7:
                    monthInText = "juli";
                    break;
                case 8:
                    monthInText = "augusti";
                    break;
                case 9:
                    monthInText = "september";
                    break;
                case 10:
                    monthInText = "oktober";
                    break;
                case 11:
                    monthInText = "november";
                    break;
                case 12:
                    monthInText = "december";
                    break;
            }

            if (DateTime.DayOfWeek.ToString().Equals("Monday"))
            {
                dayinText = "Måndag";

            }
            else if (DateTime.DayOfWeek.ToString().Equals("Tuesday"))
            {
                dayinText = "Tisdag";

            }
            else if (DateTime.DayOfWeek.ToString().Equals("Wednesday"))
            {
                dayinText = "Onsdag";

            }
            else if (DateTime.DayOfWeek.ToString().Equals("Thursday"))
            {
                dayinText = "Torsdag";

            }
            else if (DateTime.DayOfWeek.ToString().Equals("Friday"))
            {
                dayinText = "Fredag";

            }
            else if (DateTime.DayOfWeek.ToString().Equals("Saturday"))
            {
                dayinText = "Lördag";

            }
            else if (DateTime.DayOfWeek.ToString().Equals("Sunday"))
            {
                dayinText = "Söndag";

            }
            string fullDate = dayinText + ", " + day + " " + monthInText + " " + year;


            return fullDate;
        }

        public ActionResult Index(string searchString)
        {
            var forumPosts = from s in db.Fora
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                forumPosts = forumPosts.Where(s => s.Category.Equals(searchString));
            }
            return View(forumPosts);

        }

        // GET: FormalBlogPosts/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            using (var context = new ApplicationDbContext())
        //            {
        //                var currentUser = User.Identity.GetUserId();
        //                var postId = id.Value;
        //            //    var exists = context.ViewedNotifications
        //            //        .Any(x => x.PostId == postId &&
        //            //                  x.PostType == postType &&
        //            //                  x.UserId == currentUser);
        //            //    if (!exists)
        //            //    {
        //            //        var viewedNotification = new ViewedNotifications
        //            //        {
        //            //            PostId = postId,
        //            //            UserId = currentUser,
        //            //            PostType = postType,
        //            //            TimeStamp = DateTime.Now
        //            //        };
        //            //        context.ViewedNotifications.Add(viewedNotification);
        //            //        context.SaveChanges();
        //            //    }
        //            //}
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    FormalBlogPost formalBlogPost = db.BlogPosts.Find(id);
        //    if (formalBlogPost == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(formalBlogPost);
        //}



        // GET: Forums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // GET: FormalBlogPosts/Create
        public ActionResult Create()
        {
            var categories = db.ForumPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (ForumPostCategory ct in categories)
            {
                categorylist.Add(ct.CategoryName);
            }
            ViewBag.CategoryList = categorylist;

            return View();
        }

        // POST: FormalBlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Entry,Creator,DateTime,Category,FileName")] Forum forum, HttpPostedFileBase file)
        {
            var categories = db.ForumPostCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (ForumPostCategory ct in categories)
            {
                categorylist.Add(ct.CategoryName);
            }
            ViewBag.CategoryList = categorylist;
            forum.Creator = User.Identity.Name;
            forum.DateTime = DateTime.Now;



            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileToSave = Path.Combine(Server.MapPath("~/ForumPostUploads"), fileName);
                file.SaveAs(fileToSave);
                forum.FileName = fileName;
            }

            db.Fora.Add(forum);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: FormalBlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: FormalBlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Entry,Creator,DateTime,Category,FileName")] Forum forum)
        {
            forum.Creator = User.Identity.Name;
            forum.DateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(forum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forum);
        }

        // GET: FormalBlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum forum = db.Fora.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        // POST: FormalBlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forum forum = db.Fora.Find(id);
            db.Fora.Remove(forum);
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








//// GET: Forums/Create
//public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Forums/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Title,Entry,Creator,DateTime,Category,FileName")] Forum forum)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Fora.Add(forum);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(forum);
//        }

//        // GET: Forums/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Forum forum = db.Fora.Find(id);
//            if (forum == null)
//            {
//                return HttpNotFound();
//            }
//            return View(forum);
//        }

//        // POST: Forums/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Title,Entry,Creator,DateTime,Category,FileName")] Forum forum)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(forum).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(forum);
//        }

//        // GET: Forums/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Forum forum = db.Fora.Find(id);
//            if (forum == null)
//            {
//                return HttpNotFound();
//            }
//            return View(forum);
//        }

//        // POST: Forums/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Forum forum = db.Fora.Find(id);
//            db.Fora.Remove(forum);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
