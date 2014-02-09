using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesEventManager.Models;

namespace GamesEventManager.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ZipCodeViewModel());
        }

        [HttpPost]
        public ActionResult Index(ZipCodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var upcomingEvents = new UpcomingEventsViewModel(model.ZipCode);
                if (upcomingEvents.Valid) return View("Map", upcomingEvents);
            }

            ViewBag.Error = "Zip code not found.";
            return View("Error");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}