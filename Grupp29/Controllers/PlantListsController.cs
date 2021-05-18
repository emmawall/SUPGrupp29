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
        public static string SelectedFilter { get; set; }

        [HttpPost]
        public ActionResult SetFilter(String filter)
        {
            SelectedFilter = filter;
            return RedirectToAction("Index");
        }

        public PlantListsController()
        {
        }

        [HttpPost]
        public List<String> GetCategories()
        {
            List<String> namesOfPlantCategory = new List<string>();
            foreach (PlantCategory Category in db.PlantCategories.ToList())
            {
                namesOfPlantCategory.Add(Category.PlantCategoryName);
            }
            return namesOfPlantCategory;
        }

        public ActionResult Index(string searchString)
        {
            var plantPosts = from s in db.PlantLists
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                plantPosts = plantPosts.Where(s => s.PlantCategory.Equals(searchString));
            }
            return View(plantPosts);

        }

        //public ActionResult Index()
        //{
        //    return View(db.PlantLists.ToList());
        //}



        //public static PlantList GetIdFromPlant (int plantId)
        //{

        //    ApplicationDbContext dbContext = new ApplicationDbContext();

        //    return dbContext.PlantLists.Find(plantId);
        //}

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
        public ActionResult Create(/*HttpPostedFileBase imageFile*/)
        {
            var categories = db.PlantCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (PlantCategory ct in categories)
            {
                categorylist.Add(ct.PlantCategoryName);
            }
            ViewBag.CategoryList = categorylist;

            return View();
            //var filename = "";

            //if (imageFile == null)
            //{
            //    filename = "DefaultPlant.png";

            //} else {
            //    filename = imageFile.FileName;
            //    var filePath = Path.Combine(Server.MapPath("~/Image"), filename);

            //    imageFile.SaveAs(filePath);
            //}

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

            //return View();
        }

        // POST: PlantLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantId,PlantImg,ImgDesc,PlantName,Description,WaterNeed,Location,PlantCategory")] PlantList plantList, HttpPostedFileBase file)
        {
            var categories = db.PlantCategories.ToList();
            List<string> categorylist = new List<string>();
            foreach (PlantCategory ct in categories)
            {
                categorylist.Add(ct.PlantCategoryName);
            }
            ViewBag.CategoryList = categorylist;
        
            if (file != null)
            {

                string fileName = Path.GetFileName(file.FileName);
                string fileToSave = Path.Combine(Server.MapPath("~/Image"), fileName);
                file.SaveAs(fileToSave);
                plantList.PlantImg = fileName;
            }
            
                db.PlantLists.Add(plantList);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult Edit([Bind(Include = "PlantId,PlantName,Description,WaterNeed,Location,PlantCategory")] PlantList plantList)
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

        // GET: Search
        public ActionResult Search()
        {
            return View();
        }
        //public ActionResult Index(string searchedPlant)
        //{

        //    var ctx = new ApplicationDbContext();
        //    List<PlantList> list = ctx.PlantLists.Where(m => m.PlantName.Contains(searchedPlant)).ToList();

        //    List<PlantList> searchList = new List<PlantList>();

        //    foreach (PlantList plant in list)
        //    {

        //        searchList.Add(new PlantList
        //        {
        //            PlantImg = plant.PlantImg,
        //            PlantName = plant.PlantName

        //        });
        //    }

        //    return View(searchList);
        //}

        public ActionResult ShowPlant(int? id)
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
