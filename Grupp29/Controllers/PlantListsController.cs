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

namespace Grupp29.Controllers
{
    public class PlantListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlantLists
        public ActionResult Index()
        {
            return View(db.PlantLists.ToList());
        }

        // GET: PlantLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantList plantList = db.PlantLists.Find(id);
            if (plantList == null)
            {
                return HttpNotFound();
            }
            return View(plantList);
        }

        // GET: PlantLists/Create
        public ActionResult Create(HttpPostedFileBase imageFile)
        {
            var filename = "";

            if (imageFile == null)
            {
                filename = "DefaultPlant.png";

            } else {
                filename = imageFile.FileName;
                var filePath = Path.Combine(Server.MapPath("~/Image"), filename);

                imageFile.SaveAs(filePath);
            }

            //using (var db = new ApplicationDbContext())

            //    if (ModelState.IsValid)
            //    {
            //        var plant = new PlantList
            //        {
            //            PlantImg = model.PlantImg,
            //            PlantName = model.PlantName,
            //            Description = model.Description,
            //            WaterNeed = model.WaterNeed,
            //            Location = model.Location
            //        };
            //    }

                return View();
        }

        // POST: PlantLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantId,PlantImg,PlantName,Description,WaterNeed,Location")] PlantList plantList)
        {
            if (ModelState.IsValid)
            {
                db.PlantLists.Add(plantList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantList);
        }

        // GET: PlantLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantList plantList = db.PlantLists.Find(id);
            if (plantList == null)
            {
                return HttpNotFound();
            }
            return View(plantList);
        }

        // POST: PlantLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantId,PlantName,Description,WaterNeed,Location")] PlantList plantList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantList);
        }

        // GET: PlantLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantList plantList = db.PlantLists.Find(id);
            if (plantList == null)
            {
                return HttpNotFound();
            }
            return View(plantList);
        }

        // POST: PlantLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantList plantList = db.PlantLists.Find(id);
            db.PlantLists.Remove(plantList);
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
