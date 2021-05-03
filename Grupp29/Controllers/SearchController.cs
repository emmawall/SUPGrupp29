using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;

namespace Grupp29.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Search
        //public ActionResult Search()
        //{
        //    return View();
        //}

        public ActionResult Search(string searchedPlant)
        {

            var ctx = new ApplicationDbContext();
            List<PlantList> list = ctx.PlantLists.Where(m => m.PlantName.Contains(searchedPlant)).ToList();

            List<PlantList> searchList = new List<PlantList>();

            foreach (PlantList plant in list)
            {

                searchList.Add(new PlantList
                {
                    PlantImg = plant.PlantImg,
                    PlantName = plant.PlantName

                });
            }

            return View(searchList);
        }

        //public ActionResult ShowPlant(List<PlantList> list)
        //{
        //    return View(list);
        //}

        //public static PlantList GetIdFromPlant(int plantId)
        //{

        //    ApplicationDbContext dbContext = new ApplicationDbContext();

        //    return dbContext.PlantLists.Find(plantId);
        //}

        //public ActionResult ShowPlant (string plant)
        //{
        //    var ctx = new ApplicationDbContext();
        //    var plantList = new PlantList();
        //    var plantAccount = ctx.PlantLists.FirstOrDefault(a => a.PlantId.Equals(plant));

        //    plantList.PlantImg = plantAccount.PlantImg;
        //    plantList.PlantName = plantAccount.PlantName;

        //    return View("Details", plantList);
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

    }
}