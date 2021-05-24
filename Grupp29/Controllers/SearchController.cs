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