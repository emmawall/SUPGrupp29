using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupp29.Controllers
{
    public class PlantQuizController : Controller
    {
        // GET: PlantQuiz
        public ActionResult Quiz()
        {
            return View();
        }
    }
}