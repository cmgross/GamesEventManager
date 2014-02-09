using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesEventManager.DataLayer;
using GamesEventManager.Models;

namespace GamesEventManager.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(EventService.GetAll().ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event gamesEvent)
        {
            if (ModelState.IsValid)
            {
                try
                {//TODO: have a valid address check for create and edit posts before sending to DB
                    EventService.Create(gamesEvent);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    ViewBag.Error = "Couldn't insert new athlete into database: " + exception.InnerException;
                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(EventService.GetEvent(id));
        }

        [HttpPost]
        public ActionResult Edit(Event gameEvent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   EventService.UpdateEvent(gameEvent);
                    return RedirectToAction("Index");
                }
                catch (Exception exception)
                {
                    ViewBag.Error = "Couldn't update event in database: " + exception.InnerException;
                    return View("Error");
                }
            }
            ViewBag.Error = "This submission could not be accepted as a required field was missing";
            return View("Error");
        }
    }
}